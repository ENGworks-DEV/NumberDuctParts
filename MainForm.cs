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

namespace NumberParts
{
	public class MainForm : Window, IComponentConnector
	{
		public static System.Drawing.Color ColorSelected;

		public ColorDialog colorDialog = new ColorDialog();

		private ExternalCommandData p_commanddata;

		public Document _doc;

		public UIApplication uiApp;

		internal System.Windows.Controls.TextBox PrefixBox;

		internal System.Windows.Controls.TextBox NumberBox;

		internal System.Windows.Controls.TextBox SeparatorBox;

		internal System.Windows.Controls.Button button;

		internal System.Windows.Controls.CheckBox checkBoxDuplicates;

		internal System.Windows.Controls.TextBox textBox;

		private bool _contentLoaded;

		internal static string Separator
		{
			get;
			set;
		}

		public MainForm(ExternalCommandData cmddata_p)
		{
			this.p_commanddata = cmddata_p;
			this.InitializeComponent();
			this.uiApp = cmddata_p.Application;
			UIDocument uiDoc = this.uiApp.ActiveUIDocument;
			this._doc = uiDoc.Document;
			List<string> conf = tools.readConfig();
			MainForm.ColorSelected = System.Drawing.Color.FromArgb(1, 255, 0, 0);
			bool flag = conf != null && conf.Count == 3;
			if (flag)
			{
				this.PrefixBox.Text = conf[0];
				this.SeparatorBox.Text = conf[1];
				this.NumberBox.Text = conf[2];
			}
		}

		private void textChangedEventHandler(object sender, TextChangedEventArgs args)
		{
			int c;
			bool isNumeric = int.TryParse(this.NumberBox.Text, out c);
			bool flag = isNumeric;
			if (flag)
			{
				tools.count = c;
			}
			else
			{
				new SuffixContent
				{
					Topmost = true,
					WindowStartupLocation = WindowStartupLocation.CenterScreen
				}.ShowDialog();
			}
		}

		private void TESTT(object sender, RoutedEventArgs el)
		{
			Connector CurrentConnector = null;
			List<Element> RunElements = new List<Element>();
			List<ElementId> RunElementsId = new List<ElementId>();
			base.Hide();
			Element e;
			using (Transaction AssingPartNumberT = new Transaction(tools.uidoc.Document, "Assing Part Number"))
			{
				AssingPartNumberT.Start();
				e = tools.NewSelection();
				AssingPartNumberT.Commit();
			}
			ConnectorSet connectors = null;
			connectors = this.getConnectorSetFromElement(e);
			int connectCount = 0;
			foreach (Connector c in connectors)
			{
				bool flag = c.IsConnected && c.ConnectorType.ToString() != "Curve" && this.ConnectionCheck(c) != 0;
				if (flag)
				{
					connectCount += this.ConnectionCheck(c);
					CurrentConnector = c;
				}
			}
			bool flag2 = connectCount >= 2;
			if (flag2)
			{
				this.CheckDoubleConn(ref connectCount, ref connectors, ref CurrentConnector);
				bool flag3 = connectCount >= 2;
				if (flag3)
				{
					System.Windows.MessageBox.Show("The elements is not an endpoint", "warning");
					base.Show();
				}
			}
			bool flag4 = connectCount == 0;
			if (flag4)
			{
				System.Windows.MessageBox.Show("The element has no connection", "warning");
				base.Show();
			}
			bool flag5 = connectCount == 1;
			if (flag5)
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
					RunElements.Add(tempElem);
					RunElementsId.Add(tempElem.Id);
					foreach (Connector fcon in TempConnectors)
					{
						bool flag6 = fcon.IsConnected && fcon.ConnectorType.ToString() != "Curve";
						if (flag6)
						{
							bool flag7 = this.ConnectionCheck(fcon) != 0;
							if (flag7)
							{
								countConnect++;
								bool isEmpty = fcon.AllRefs.IsEmpty;
								if (isEmpty)
								{
									TaskDialog.Show("sss", "ddd");
								}
							}
						}
					}
					bool flag8 = countConnect == 1 && iterationsCount != 0;
					if (flag8)
					{
						tempValue = 2;
					}
					else
					{
						ConnectorSet secondary = CurrentConnector.AllRefs;
						foreach (Connector cone in secondary)
						{
							bool flag9 = !RunElementsId.Contains(cone.Owner.Id);
							if (flag9)
							{
								tempElem = this._doc.GetElement(cone.Owner.Id);
							}
						}
						TempConnectors = this.getConnectorSetFromElement(tempElem);
						foreach (Connector connec in TempConnectors)
						{
							bool flag10 = connec.IsConnected && connec.ConnectorType.ToString() != "Curve";
							if (flag10)
							{
								foreach (Connector con in connec.AllRefs)
								{
									bool flag11 = !RunElementsId.Contains(con.Owner.Id);
									if (flag11)
									{
										CurrentConnector = connec;
									}
								}
							}
						}
					}
					iterationsCount++;
				}
				List<string> listToStringComplete = this.listToString(RunElements);
				bool flag12 = RunElements.Count != 0;
				if (flag12)
				{
					foreach (Element elmnt in RunElements)
					{
						using (Transaction AssingPartNumberT2 = new Transaction(tools.uidoc.Document, "Assing Part Number"))
						{
							tools.selectedElements.Clear();
							AssingPartNumberT2.Start();
							tools.AddToSelection(elmnt, listToStringComplete, RunElements, this.checkBoxDuplicates.IsChecked.Value);
							string partNumber = tools.createNumbering(this.PrefixBox.Text, this.SeparatorBox.Text, tools.count, this.NumberBox.Text.Length);
							foreach (Element x in tools.selectedElements)
							{
								tools.AssingPartNumber(x, partNumber);
							}
							bool flag13 = tools.selectedElements.Count != 0;
							if (flag13)
							{
								tools.count++;
							}
							int leadingZeros = (this.NumberBox.Text.Length > 1) ? (this.NumberBox.Text.Length - tools.count.ToString().Length) : 0;
							this.NumberBox.Text = new string('0', leadingZeros) + tools.count.ToString();
							tools.writeConfig(this.PrefixBox.Text, this.SeparatorBox.Text, this.NumberBox.Text);
							Options options = this.uiApp.Application.Create.NewGeometryOptions();
							AssingPartNumberT2.Commit();
						}
					}
				}
				base.Show();
			}
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
				TempConnectors = this.getConnectorSetFromElement(tempElem);
			}
			bool flag = TempConnectors != null;
			if (flag)
			{
				foreach (Connector connec in TempConnectors)
				{
					bool flag2 = MainForm.CloseEnoughForMe(connec.Origin.X, con.Origin.X);
					if (flag2)
					{
						bool flag3 = MainForm.CloseEnoughForMe(connec.Origin.Y, con.Origin.Y);
						if (flag3)
						{
							bool flag4 = MainForm.CloseEnoughForMe(connec.Origin.Z, con.Origin.Z);
							if (flag4)
							{
								tempInt = 1;
							}
						}
					}
				}
			}
			return tempInt;
		}

		private static bool CloseEnoughForMe(double value1, double value2)
		{
			return Math.Abs(value1 - value2) <= 1.0;
		}

		private void CheckDoubleConn(ref int checkValue, ref ConnectorSet connectSet, ref Connector CurrentConnector)
		{
			List<Connector> connectorList = new List<Connector>();
			List<Element> adjacentElement = new List<Element>();
			foreach (Connector c in connectSet)
			{
				bool flag = c.IsConnected && c.ConnectorType.ToString() != "Curve";
				if (flag)
				{
					connectorList.Add(c);
				}
			}
			foreach (Connector c2 in connectorList)
			{
				ConnectorSet secondary = c2.AllRefs;
				foreach (Connector cone in secondary)
				{
					adjacentElement.Add(this._doc.GetElement(cone.Owner.Id));
				}
			}
			adjacentElement = adjacentElement.Distinct<Element>().ToList<Element>();
			Connector temConnector = null;
			int count = 0;
			foreach (Element elem in adjacentElement)
			{
				foreach (Connector c3 in connectorList)
				{
					bool flag2 = this.isAdjacentValidElmt(elem, c3);
					if (flag2)
					{
						count++;
						temConnector = c3;
					}
				}
			}
			bool flag3 = count == 1;
			if (flag3)
			{
				checkValue = 1;
				CurrentConnector = temConnector;
			}
		}

		private bool isAdjacentValidElmt(Element elm, Connector conn)
		{
			bool validation = false;
			List<string> originConnectors = new List<string>();
			ConnectorSet TempConnectors = this.getConnectorSetFromElement(elm);
			foreach (Connector connec in TempConnectors)
			{
				bool flag = connec.IsConnected && connec.ConnectorType.ToString() != "Curve";
				if (flag)
				{
					originConnectors.Add(connec.Origin.ToString());
				}
			}
			bool flag2 = originConnectors.Contains(conn.Origin.ToString());
			if (flag2)
			{
				validation = true;
			}
			return validation;
		}

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

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			System.Drawing.Color color = MainForm.ColorSelected;
			base.Hide();
			int c;
			bool isNumeric = int.TryParse(this.NumberBox.Text, out c);
			bool flag = isNumeric;
			if (flag)
			{
				bool flag2 = tools.count < int.Parse(this.NumberBox.Text);
				if (flag2)
				{
					tools.count = c;
				}
			}
			else
			{
				new SuffixContent
				{
					Topmost = true,
					WindowStartupLocation = WindowStartupLocation.CenterScreen
				}.ShowDialog();
			}
			base.ShowDialog();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			this.colorDialog.ShowDialog();
			MainForm.ColorSelected = this.colorDialog.Color;
		}

		public void SeparatorBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			MainForm.Separator = this.SeparatorBox.Text;
		}

		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
		public void InitializeComponent()
		{
			bool contentLoaded = this._contentLoaded;
			if (!contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocater = new Uri("/NumberParts;component/mainform.xaml", UriKind.Relative);
				System.Windows.Application.LoadComponent(this, resourceLocater);
			}
		}

		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((CommandBinding)target).Executed += new ExecutedRoutedEventHandler(this.AddButton_Click);
				break;
			case 2:
				((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.Button_Click_2);
				break;
			case 3:
				this.PrefixBox = (System.Windows.Controls.TextBox)target;
				break;
			case 4:
				this.NumberBox = (System.Windows.Controls.TextBox)target;
				this.NumberBox.TextChanged += new TextChangedEventHandler(this.textChangedEventHandler);
				break;
			case 5:
				this.SeparatorBox = (System.Windows.Controls.TextBox)target;
				this.SeparatorBox.TextChanged += new TextChangedEventHandler(this.SeparatorBox_TextChanged);
				break;
			case 6:
				this.button = (System.Windows.Controls.Button)target;
				this.button.Click += new RoutedEventHandler(this.TESTT);
				break;
			case 7:
				this.checkBoxDuplicates = (System.Windows.Controls.CheckBox)target;
				break;
			case 8:
				this.textBox = (System.Windows.Controls.TextBox)target;
				break;
			default:
				this._contentLoaded = true;
				break;
			}
		}
	}
}
