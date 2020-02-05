using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;

namespace NumberDuctParts
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public static System.Drawing.Color ColorSelected;

        public ColorDialog colorDialog = new ColorDialog();

        private ExternalCommandData p_commanddata;

        public Document _doc;

        public UIApplication uiApp;

        public bool open = false;

        public bool checkBoxDuplicates;

        public bool RoundDuctsBool;

        public bool SnglElmtButton = true;

        internal static string Separator
        {
            get;
            set;
        }


        /// <summary>
        /// Check if the suffix is a number or not
        /// </summary>
        /// <param name="cmddata_p"></param>
        public MainForm(ExternalCommandData cmddata_p)
        {
            this.DataContext = this;
            this.p_commanddata = cmddata_p;
            this.InitializeComponent();
            this.uiApp = cmddata_p.Application;
            UIDocument uiDoc = this.uiApp.ActiveUIDocument;
            this._doc = uiDoc.Document;
            List<string> conf = tools.readConfig();
            MainForm.ColorSelected = System.Drawing.Color.FromArgb(1, 255, 0, 0);
            if (conf != null && conf.Count == 3)
            {
                this.PrefixBox.Text = conf[0];
                this.SeparatorBox.Text = conf[1];
                this.NumberBox.Text = conf[2];
            }
        }

        public string projectVersion = CommonAssemblyInfo.Number;
        public string ProjectVersion
        {
            get { return projectVersion; }
            set { projectVersion = value; }
        }

        /// <summary>
        /// Check if the suffix is a number or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            int c;
            bool isNumeric = int.TryParse(this.NumberBox.Text, out c);

            if (isNumeric)
            {
                tools.count = c;
            }
            else
            {
                SuffixContent suffixContentForm = new SuffixContent();
                suffixContentForm.Topmost = true;
                suffixContentForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                suffixContentForm.ShowDialog();   
            }
        }



        private void NumberPartButton_Click(object sender, RoutedEventArgs el)
        {
            Connector CurrentConnector = null;
            List<Element> RunElements = new List<Element>();
            List<ElementId> RunElementsId = new List<ElementId>();
            base.Hide();
            Element e;


            //Select the element only if it is a part number
            using (Transaction AssingPartNumberT = new Transaction(tools.uidoc.Document, "Assing Part Number"))
            {
                AssingPartNumberT.Start();
                e = tools.NewSelection();
                AssingPartNumberT.Commit();          
            }

            //Make sure that the user selected a valid element
            if (e == null)
            {
                goto CloseApp;
            }


            ConnectorSet connectors = this.getConnectorSetFromElement(e);
            int connectCount = 0;


            //Get the numbers of connectors of the element
            foreach (Connector c in connectors)
            {
                //Conector must be connected, must be a End conector and should have another element connected to it.
                if (c.IsConnected && c.ConnectorType.ToString() != "Curve" && this.ConnectionCheck(c) != 0)
                {
                    connectCount += 1;
                    CurrentConnector = c;
                }
            }

            //Check if the element is isolated
            if (connectCount == 0 || SnglElmtButton)
            {
                RunElements.Add(e);
                connectCount = 0;
            }

            //Check if the element has more than 2 connections
            if (connectCount >= 2)
            {
                //check if the element is a false positive
                this.CheckDoubleConn(ref connectCount, ref connectors, ref CurrentConnector);

                if (connectCount >= 2)
                {
                    System.Windows.MessageBox.Show("The elements is not an endpoint", "warning");
                    goto CloseApp;
                }
            }

            //Check if the element has 1 connection
            if (connectCount == 1)
            {
                int tempValue = 1;
                ConnectorSet TempConnectors = null;
                List<Connector> TempConnectorsList = new List<Connector>();
                Element tempElem = e;
                int iterationsCount = 0;
                TempConnectors = connectors;

                while (tempValue == 1)
                {
                    int countConnect = 0;

                    if (checkRoundDucts(RoundDuctsBool, tempElem))
                    {
                        RunElements.Add(tempElem);
                    }

                    RunElementsId.Add(tempElem.Id);

                    //Make sure that the elements are conected if connectors
                    //are geometrically aligned
                    foreach (Connector fcon in TempConnectors)
                    {
                        if (ConnectorsHelper.ConnStatus(fcon))
                        {
                            if (this.ConnectionCheck(fcon) != 0)
                            {
                                countConnect++;
                            }
                        }
                    }

                    //Check if the element is a tee
                    if(ConnectorsHelper.TeeDetect(TempConnectors))
                    {
                        tempValue = 2;
                        goto EndLoop;
                    }

                    if (countConnect == 1 && iterationsCount != 0)
                    {
                        tempValue = 2;
                        goto EndLoop;
                    }
                    else
                    {
                        ConnectorSet secondary = CurrentConnector.AllRefs;
                        foreach (Connector cone in secondary)
                        {
                           
                            if (!RunElementsId.Contains(cone.Owner.Id))
                            {
                                //Check if the following element is connected from the side
                                tempElem = this._doc.GetElement(cone.Owner.Id);

                                Category cat = tempElem.Category;
                                BuiltInCategory enumCat = (BuiltInCategory)cat.Id.IntegerValue;

                                if (enumCat.ToString() != "OST_FabricationDuctwork")
                                {
                                    tempValue = 2;
                                    goto EndLoop;
                                }

                            }
                        }



                        TempConnectors = this.getConnectorSetFromElement(tempElem);

                        foreach (Connector connec in TempConnectors)
                        {
                            //Check that the previous element is not connecting from side
                            if (!ConnectorsHelper.ConnStatus(connec))
                            {
                                foreach (Connector con in connec.AllRefs)
                                {
                                    if (RunElementsId.Contains(con.Owner.Id))
                                    {
                                        tempValue = 2;
                                        goto EndLoop;
                                    }
                                }
                            }

                            //Get the next useful connector
                            if (ConnectorsHelper.ConnStatus(connec))
                            {
                                foreach (Connector con in connec.AllRefs)
                                {
                                    if (!RunElementsId.Contains(con.Owner.Id))
                                    {
                                        CurrentConnector = connec;
                                    }
                                }
                            }
                        }
                    }
                EndLoop:
                    iterationsCount++;
                }
            }


            List<string> listToStringComplete = this.listToString(RunElements);

                if (RunElements.Count != 0)
                {
                    foreach (Element elmnt in RunElements)
                    {
                        using (Transaction AssingPartNumberT2 = new Transaction(tools.uidoc.Document, "Assing Part Number"))
                        {
                            tools.selectedElements.Clear();
                            AssingPartNumberT2.Start();
                            
                        
                            //Find all the elements that are the same in the RunElements list
                            tools.AddToSelection(elmnt, listToStringComplete, RunElements, checkBoxDuplicates);

                            //Generate the part number
                            string partNumber = tools.createNumbering(this.PrefixBox.Text, this.SeparatorBox.Text, tools.count, this.NumberBox.Text.Length);                     
                            
                            //Assign the part number to each selected element
                            foreach (Element x in tools.selectedElements)
                            {
                                tools.AssingPartNumber(x, partNumber);
                            }

                           
                            if (tools.selectedElements.Count != 0)
                            {
                                tools.count++;
                            }

                        int leadingZeros = (this.NumberBox.Text.Length > 1) ? (this.NumberBox.Text.Length - tools.count.ToString().Length) : 0;

                        if(leadingZeros>=0)
                        {
                            this.NumberBox.Text = new string('0', leadingZeros) + tools.count.ToString();
                        }
                        else
                        {
                            this.NumberBox.Text = tools.count.ToString();
                        }
                        
                        tools.writeConfig(this.PrefixBox.Text, this.SeparatorBox.Text, this.NumberBox.Text);
                            Options options = this.uiApp.Application.Create.NewGeometryOptions();
                            AssingPartNumberT2.Commit();
                        }
                    }
                }

                
                
            

        CloseApp:;
        base.ShowDialog();
        }



        private List<string> listToString(List<Element> RunElements)
        {
            List<string> listToString = new List<string>();
            List<string> elementString = new List<string>();
            foreach (Element elem in RunElements)
            {
                foreach (Parameter param in elem.GetOrderedParameters())
                {
                    elementString.Add(param.Definition.Name.ToString() + param.AsValueString());
                }
                string elementParams = string.Join(", ", elementString.ToArray());
                listToString.Add(elementParams);
            }
            return listToString;
        }

        private int ConnectionCheck(Connector con)
        {
            int tempInt = 0;
            ConnectorSet secondary = con.AllRefs;
            ConnectorSet TempConnectors = null;

            foreach (Connector f in secondary)
            {
                Element tempElem = this._doc.GetElement(f.Owner.Id);
                Category cat = tempElem.Category;
                BuiltInCategory enumCat = (BuiltInCategory)cat.Id.IntegerValue;

                if (enumCat.ToString() == "OST_FabricationDuctwork")
                { 
                  TempConnectors = this.getConnectorSetFromElement(tempElem);
                }
            }

            if (TempConnectors != null)
            {
                foreach (Connector connec in TempConnectors)
                {
                    if (MainForm.CloseEnoughForMe(connec.Origin.X, con.Origin.X) &&
                        MainForm.CloseEnoughForMe(connec.Origin.Y, con.Origin.Y) &&
                        MainForm.CloseEnoughForMe(connec.Origin.Z, con.Origin.Z))
                    {
                        tempInt = 1;
                    }
                }
            }

            return tempInt;
        }

        private static bool CloseEnoughForMe(double value1, double value2)
        {
            return Math.Abs(value1 - value2) <= 1.0;
        }


        /// <summary>
        /// Get the current conector of the element
        /// </summary>
        /// <param name="elm"></param>
        /// <param name="conn"></param>
        private void CheckDoubleConn(ref int checkValue, ref ConnectorSet connectSet, ref Connector CurrentConnector)
        {
            List<Connector> connectorList = new List<Connector>();
            List<Element> adjacentElement = new List<Element>();


            foreach (Connector c in connectSet)
            {
                if (ConnectorsHelper.ConnStatus(c))
                {
                    ConnectorSet secondary = c.AllRefs;
                    foreach (Connector cone in secondary)
                    {
                    adjacentElement.Add(this._doc.GetElement(cone.Owner.Id));
                    }
                }
            }

            adjacentElement = adjacentElement.Distinct<Element>().ToList<Element>();
            Connector temConnector = null;
            int count = 0;

            foreach (Element elem in adjacentElement)
            {
                foreach (Connector c3 in connectorList)
                {
                    if (this.isAdjacentValidElmt(elem, c3))
                    {
                        count++;
                        temConnector = c3;
                    }
                }
            }
            
            if (count == 1)
            {
                checkValue = 1;
                CurrentConnector = temConnector;
            }
        }


        /// <summary>
        /// Check if the adjacent element is valid
        /// </summary>
        /// <param name="elm"></param>
        /// <param name="conn"></param>
        private bool isAdjacentValidElmt(Element elm, Connector conn)
        {
            bool validation = false;
            List<string> originConnectors = new List<string>();
            ConnectorSet TempConnectors = this.getConnectorSetFromElement(elm);
            foreach (Connector connec in TempConnectors)
            {
                if (connec.IsConnected && connec.ConnectorType.ToString() != "Curve")
                {
                    originConnectors.Add(connec.Origin.ToString());
                }
            }
            if (originConnectors.Contains(conn.Origin.ToString()))
            {
                validation = true;
            }
            return validation;
        }

        /// <summary>
        /// Get The connector set of an element
        /// </summary>
        /// <param name="elem"></param>
        private ConnectorSet getConnectorSetFromElement(Element elem)
        {
            ConnectorSet connectors = null;
            bool flag = elem is FamilyInstance;
            if (flag)
            {
                MEPModel i = ((FamilyInstance)elem).MEPModel;
                connectors = i.ConnectorManager.Connectors;
            }
            else
            {
                bool flag2 = elem is FabricationPart;
                if (flag2)
                {
                    connectors = ((FabricationPart)elem).ConnectorManager.Connectors;
                }
                else
                {
                    bool flag3 = elem is MEPCurve;
                    if (flag3)
                    {
                        connectors = ((MEPCurve)elem).ConnectorManager.Connectors;
                    }
                    else
                    {
                        Debug.Assert(elem.GetType().IsSubclassOf(typeof(MEPCurve)), "expected all candidate connector provider elements to be either family instances or derived from MEPCurve");
                    }
                }
            }
            return connectors;
        }


        /// <summary>
        /// Reset values in view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tools.resetView();
        }


        /// <summary>
        /// Show Color dialog and set selected color to variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            colorDialog.ShowDialog();
            ColorSelected = colorDialog.Color;
        }

        
        /// <summary>
        /// if checkbox round ducts is checked filter round ducts
        /// </summary>
        bool checkRoundDucts(bool checkBox, Element elm)
        {
            bool result = false;

            if (checkBox)
            {
                result = true;
            }
            else
            {
                if (elm.LookupParameter("Main Primary Diameter") != null)
                {

                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }


        /// <summary>
        /// Writes string used as separator to an internal field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SeparatorBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Separator = this.SeparatorBox.Text;
        }


        /// <summary>
        /// Create an instance of the confirmDeleteForm.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConfirmDelete confirmDeleteForm = new ConfirmDelete();
            confirmDeleteForm.Topmost = true;
            confirmDeleteForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            confirmDeleteForm.ShowDialog();
        }


        /// <summary>
        /// Button close form when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Button close form when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFormSettings SettingsForm = new MainFormSettings(this.p_commanddata);
            SettingsForm.Topmost = true;
            SettingsForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SettingsForm.ShowDialog();

            checkBoxDuplicates = SettingsForm.checkBoxDuplicates.IsChecked.Value;
            RoundDuctsBool = SettingsForm.Round_Ducts.IsChecked.Value;
            SnglElmtButton = SettingsForm.SnglElmtButton.IsChecked.Value;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)

        {
            this.DragMove();
        }

        private void Title_Link(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://engworks.com/Number-Duct-parts/");
        }

        /// <summary>
        /// Button collapse or expand options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            
            if(open)
            {
                
                MainWindow.MinHeight = 280;
                MainWindow.MaxHeight = 280;
                DisplaceDN.Visibility = System.Windows.Visibility.Hidden;
                DiplaceUp.Visibility = System.Windows.Visibility.Hidden;
                LineDivisionDisplace.Visibility = System.Windows.Visibility.Hidden;
                LabelDisplace.Visibility = System.Windows.Visibility.Hidden;
                ResetValuesButton.Visibility = System.Windows.Visibility.Hidden;
                ResetColorButton.Visibility = System.Windows.Visibility.Hidden;
                open = false;
            }
            else
            {
                
                MainWindow.MinHeight = 430;
                MainWindow.MaxHeight = 430;
                DisplaceDN.Visibility = System.Windows.Visibility.Visible;
                DiplaceUp.Visibility = System.Windows.Visibility.Visible;
                LineDivisionDisplace.Visibility = System.Windows.Visibility.Visible;
                LabelDisplace.Visibility = System.Windows.Visibility.Visible;
                ResetValuesButton.Visibility = System.Windows.Visibility.Visible;
                ResetColorButton.Visibility = System.Windows.Visibility.Visible;

                open = true;
            }  
        }
    }

}

