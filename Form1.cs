using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Guna.UI.WinForms;
using Microsoft.VisualBasic;
using Steam_Setup.Properties;

namespace Steam_Setup
{
	// Token: 0x02000002 RID: 2
	public class Form1 : Form
	{
		// Token: 0x06000002 RID: 2
		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "mouse_event", ExactSpelling = true, SetLastError = true)]
		private static extern bool apimouse_event(int dwFlags, int dX, int dY, int cButtons, int dwExtraInfo);

		// Token: 0x06000003 RID: 3
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState(int key);

		// Token: 0x06000004 RID: 4
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "GetMessageExtraInfo", ExactSpelling = true, SetLastError = true)]
		private static extern int apiGetMessageExtraInfo();

		// Token: 0x06000005 RID: 5
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int cch);

		// Token: 0x06000006 RID: 6
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x06000007 RID: 7
		[DllImport("user32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

		// Token: 0x06000008 RID: 8
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		// Token: 0x06000009 RID: 9
		[DllImport("user32.dll")]
		private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

		// Token: 0x0600000A RID: 10
		[DllImport("USER32.dll")]
		private static extern short GetKeyState(Keys nVirtKey);

		// Token: 0x0600000B RID: 11
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

		// Token: 0x0600000C RID: 12
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

		// Token: 0x0600000D RID: 13
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x0600000E RID: 14
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

		// Token: 0x0600000F RID: 15 RVA: 0x00002058 File Offset: 0x00000258
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020D8 File Offset: 0x000002D8
		public void Delay(double dblSecs)
		{
			DateAndTime.Now.AddSeconds(1.1574074074074073E-05);
			DateTime t = DateAndTime.Now.AddSeconds(1.1574074074074073E-05).AddSeconds(dblSecs);
			while (DateTime.Compare(DateAndTime.Now, t) <= 0)
			{
				Application.DoEvents();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000213C File Offset: 0x0000033C
		private string GetCaptionOfActiveWindow()
		{
			string result = string.Empty;
			IntPtr foregroundWindow = Form1.GetForegroundWindow();
			int num = Form1.GetWindowTextLength(foregroundWindow) + 1;
			StringBuilder stringBuilder = new StringBuilder(num);
			bool flag = Form1.GetWindowText(foregroundWindow, stringBuilder, num) > 0;
			if (flag)
			{
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002188 File Offset: 0x00000388
		private void check()
		{
			bool flag = this.gunaLabel73.Text == "csprint";
			if (flag)
			{
				bool flag2 = this.gunaShadowPanel2.BaseColor == Color.FromArgb(80, 2, 100);
				if (flag2)
				{
					this.gunaShadowPanel2.BaseColor = Color.FromArgb(80, 2, 100);
				}
				else
				{
					this.gunaShadowPanel2.BaseColor = Color.FromArgb(15, 15, 15);
				}
			}
			bool flag3 = this.gunaLabel74.Text == "breakblocks";
			if (flag3)
			{
				this.gunaShadowPanel3.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaShadowPanel3.BaseColor = Color.FromArgb(15, 15, 15);
			}
			bool flag4 = this.gunaLabel75.Text == "disable";
			if (flag4)
			{
				this.gunaShadowPanel4.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaShadowPanel4.BaseColor = Color.FromArgb(15, 15, 15);
			}
			bool flag5 = this.gunaLabel76.Text == "doubleclick";
			if (flag5)
			{
				this.gunaShadowPanel5.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaShadowPanel5.BaseColor = Color.FromArgb(15, 15, 15);
			}
			bool flag6 = this.gunaLabel77.Text == "riquere";
			if (flag6)
			{
				this.gunaShadowPanel6.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaShadowPanel6.BaseColor = Color.FromArgb(15, 15, 15);
			}
			bool flag7 = this.gunaLabel78.Text == "disablee";
			if (flag7)
			{
				this.gunaShadowPanel9.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaShadowPanel9.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002384 File Offset: 0x00000584
		private async void reach1()
		{
			bool flag = this.gunaAdvenceButton12.Text == "Disable";
			if (flag)
			{
				double num = 3.0;
				double num2 = 0.0;
				try
				{
					bool flag2 = this.bunifuSlider6.Value == 0;
					if (flag2)
					{
						num2 = 3.07;
					}
					else
					{
						bool flag3 = this.bunifuSlider6.Value == 1;
						if (flag3)
						{
							num2 = 3.16;
						}
						else
						{
							bool flag4 = this.bunifuSlider6.Value == 2;
							if (flag4)
							{
								num2 = 3.24;
							}
							else
							{
								bool flag5 = this.bunifuSlider6.Value == 3;
								if (flag5)
								{
									num2 = 3.37;
								}
								else
								{
									bool flag6 = this.bunifuSlider6.Value == 4;
									if (flag6)
									{
										num2 = 3.45;
									}
									else
									{
										bool flag7 = this.bunifuSlider6.Value == 5;
										if (flag7)
										{
											num2 = 3.57;
										}
										else
										{
											bool flag8 = this.bunifuSlider6.Value == 6;
											if (flag8)
											{
												num2 = 3.65;
											}
											else
											{
												bool flag9 = this.bunifuSlider6.Value == 7;
												if (flag9)
												{
													num2 = 3.76;
												}
												else
												{
													bool flag10 = this.bunifuSlider6.Value == 8;
													if (flag10)
													{
														num2 = 3.86;
													}
													else
													{
														bool flag11 = this.bunifuSlider6.Value == 9;
														if (flag11)
														{
															num2 = 3.95;
														}
														else
														{
															bool flag12 = this.bunifuSlider6.Value == 10;
															if (flag12)
															{
																num2 = 4.07;
															}
															else
															{
																bool flag13 = this.bunifuSlider6.Value == 11;
																if (flag13)
																{
																	num2 = 4.16;
																}
																else
																{
																	bool flag14 = this.bunifuSlider6.Value == 12;
																	if (flag14)
																	{
																		num2 = 4.24;
																	}
																	else
																	{
																		bool flag15 = this.bunifuSlider6.Value == 13;
																		if (flag15)
																		{
																			num2 = 4.37;
																		}
																		else
																		{
																			bool flag16 = this.bunifuSlider6.Value == 14;
																			if (flag16)
																			{
																				num2 = 4.44;
																			}
																			else
																			{
																				bool flag17 = this.bunifuSlider6.Value == 15;
																				if (flag17)
																				{
																					num2 = 4.57;
																				}
																				else
																				{
																					bool flag18 = this.bunifuSlider6.Value == 16;
																					if (flag18)
																					{
																						num2 = 4.64;
																					}
																					else
																					{
																						bool flag19 = this.bunifuSlider6.Value == 17;
																						if (flag19)
																						{
																							num2 = 4.77;
																						}
																						else
																						{
																							bool flag20 = this.bunifuSlider6.Value == 18;
																							if (flag20)
																							{
																								num2 = 4.84;
																							}
																							else
																							{
																								bool flag21 = this.bunifuSlider6.Value == 19;
																								if (flag21)
																								{
																									num2 = 4.97;
																								}
																								else
																								{
																									bool flag22 = this.bunifuSlider6.Value == 20;
																									if (flag22)
																									{
																										num2 = 5.07;
																									}
																									else
																									{
																										bool flag23 = this.bunifuSlider6.Value == 21;
																										if (flag23)
																										{
																											num2 = 5.17;
																										}
																										else
																										{
																											bool flag24 = this.bunifuSlider6.Value == 22;
																											if (flag24)
																											{
																												num2 = 5.24;
																											}
																											else
																											{
																												bool flag25 = this.bunifuSlider6.Value == 23;
																												if (flag25)
																												{
																													num2 = 5.37;
																												}
																												else
																												{
																													bool flag26 = this.bunifuSlider6.Value == 24;
																													if (flag26)
																													{
																														num2 = 5.44;
																													}
																													else
																													{
																														bool flag27 = this.bunifuSlider6.Value == 25;
																														if (flag27)
																														{
																															num2 = 5.57;
																														}
																														else
																														{
																															bool flag28 = this.bunifuSlider6.Value == 26;
																															if (flag28)
																															{
																																num2 = 5.64;
																															}
																															else
																															{
																																bool flag29 = this.bunifuSlider6.Value == 27;
																																if (flag29)
																																{
																																	num2 = 5.77;
																																}
																																else
																																{
																																	bool flag30 = this.bunifuSlider6.Value == 28;
																																	if (flag30)
																																	{
																																		num2 = 5.84;
																																	}
																																	else
																																	{
																																		bool flag31 = this.bunifuSlider6.Value == 29;
																																		if (flag31)
																																		{
																																			num2 = 5.94;
																																		}
																																		else
																																		{
																																			bool flag32 = this.bunifuSlider6.Value == 30;
																																			if (flag32)
																																			{
																																				num2 = 6.07;
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					this.gunaAdvenceButton12.Text = "wait";
					Form1.pl1 = Form1.pl2.ScanArray(Form1.pl2.GetPID("javaw"), "00 00 00 00 00 00 08 40 00 00 00 00 00");
					int num5;
					for (int i = 0; i < Form1.pl1.Count<IntPtr>(); i = num5 + 1)
					{
						double num3 = this.vamemory_0.ReadDouble(Form1.pl1[i]);
						bool flag33 = num3 == num;
						if (flag33)
						{
							this.vamemory_0.WriteDouble(Form1.pl1[i], num2);
						}
						num5 = i;
					}
					this.gunaAdvenceButton12.Text = "Disable";
					return;
				}
				catch
				{
				}
				bool flag34 = this.gunaAdvenceButton12.Text == "Disable";
				if (flag34)
				{
					try
					{
						this.gunaAdvenceButton12.Text = "wait";
						num2 = 3.0;
						Form1.pl1 = Form1.pl2.ScanArray(Form1.pl2.GetPID("javaw"), "00 00 00 00 00 00 08 40 00 00 00 00 00");
						int num5;
						for (int j = 0; j < Form1.pl1.Count<IntPtr>(); j = num5 + 1)
						{
							double num4 = this.vamemory_0.ReadDouble(Form1.pl1[j]);
							bool flag35 = num4 == num;
							if (flag35)
							{
								this.vamemory_0.WriteDouble(Form1.pl1[j], num2);
							}
							num5 = j;
						}
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023C0 File Offset: 0x000005C0
		private async void reach2()
		{
			double num = 3.0;
			double num2 = 0.0;
			bool flag = this.gunaAdvenceButton12.Text == "Disable";
			if (flag)
			{
				try
				{
					this.gunaAdvenceButton12.Text = "Disable";
					num2 = 3.0;
					Form1.pl1 = Form1.pl2.ScanArray(Form1.pl2.GetPID("javaw"), "00 00 00 00 00 00 08 40 00 00 00 00 00");
					int num4;
					for (int i = 0; i < Form1.pl1.Count<IntPtr>(); i = num4 + 1)
					{
						double num3 = this.vamemory_0.ReadDouble(Form1.pl1[i]);
						bool flag2 = num3 == num;
						if (flag2)
						{
							this.vamemory_0.WriteDouble(Form1.pl1[i], num2);
						}
						num4 = i;
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023FC File Offset: 0x000005FC
		private async void velocityj()
		{
			bool flag = this.gunaAdvenceButton16.Text == "Disable";
			if (flag)
			{
				double num = 8000.0;
				double num2 = 0.0;
				try
				{
					bool flag2 = this.bunifuSlider9.Value == 0;
					if (flag2)
					{
						num2 = 8000.0;
					}
					bool flag3 = this.bunifuSlider9.Value == 10;
					if (flag3)
					{
						num2 = 8200.0;
					}
					bool flag4 = this.bunifuSlider9.Value < 20;
					if (flag4)
					{
						num2 = 8400.0;
					}
					bool flag5 = this.bunifuSlider9.Value == 30;
					if (flag5)
					{
						num2 = 8500.0;
					}
					bool flag6 = this.bunifuSlider9.Value < 40;
					if (flag6)
					{
						num2 = 8700.0;
					}
					bool flag7 = this.bunifuSlider9.Value < 50;
					if (flag7)
					{
						num2 = 8900.0;
					}
					bool flag8 = this.bunifuSlider9.Value < 70;
					if (flag8)
					{
						num2 = 9500.0;
					}
					bool flag9 = this.bunifuSlider9.Value < 80;
					if (flag9)
					{
						num2 = 9700.0;
					}
					bool flag10 = this.bunifuSlider9.Value < 90;
					if (flag10)
					{
						num2 = 10000.0;
					}
					bool flag11 = this.bunifuSlider9.Value == 100;
					if (flag11)
					{
						num2 = 27000.0;
					}
					Form1.pl1 = Form1.pl2.ScanArray(Form1.pl2.GetPID("javaw"), "00 00 00 00 00 40 BF 40");
					int num4;
					for (int i = 0; i < Form1.pl1.Count<IntPtr>(); i = num4 + 1)
					{
						double num3 = this.vamemory_0.ReadDouble(Form1.pl1[i]);
						bool flag12 = num3 == num;
						if (flag12)
						{
							this.vamemory_0.WriteDouble(Form1.pl1[i], num2);
						}
						num4 = i;
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002438 File Offset: 0x00000638
		private void velocityi()
		{
			double num = 8000.0;
			double pData = 8000.0;
			Form1.pl1 = Form1.pl2.ScanArray(Form1.pl2.GetPID("javaw"), "00 00 00 00 00 40 BF 40");
			for (int i = 0; i < Form1.pl1.Count<IntPtr>(); i++)
			{
				double num2 = this.vamemory_0.ReadDouble(Form1.pl1[i]);
				bool flag = num2 == num;
				if (flag)
				{
					this.vamemory_0.WriteDouble(Form1.pl1[i], pData);
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000024D8 File Offset: 0x000006D8
		private async void het()
		{
			this.gunaAdvenceButton23.Enabled = false;
			await this.Wait(200);
			this.gunaAdvenceButton23.Enabled = true;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002514 File Offset: 0x00000714
		private void tab()
		{
			bool flag = this.gunaLabel33.Text == "combat";
			if (flag)
			{
				this.gunaImageCheckBox1.Enabled = false;
				this.gunaImageCheckBox2.Enabled = true;
				this.gunaImageCheckBox3.Enabled = true;
				this.gunaImageCheckBox1.Checked = true;
				this.gunaImageCheckBox2.Checked = false;
				this.gunaImageCheckBox3.Checked = false;
			}
			bool flag2 = this.gunaLabel33.Text == "movement";
			if (flag2)
			{
				this.gunaImageCheckBox2.Enabled = false;
				this.gunaImageCheckBox1.Enabled = true;
				this.gunaImageCheckBox3.Enabled = true;
				this.gunaImageCheckBox2.Checked = true;
				this.gunaImageCheckBox1.Checked = false;
				this.gunaImageCheckBox3.Checked = false;
			}
			bool flag3 = this.gunaLabel33.Text == "more";
			if (flag3)
			{
				this.gunaImageCheckBox3.Enabled = false;
				this.gunaImageCheckBox2.Enabled = true;
				this.gunaImageCheckBox1.Enabled = true;
				this.gunaImageCheckBox3.Checked = true;
				this.gunaImageCheckBox2.Checked = false;
				this.gunaImageCheckBox1.Checked = false;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002660 File Offset: 0x00000860
		private async Task Wait(int ms)
		{
			await Task.Delay(ms);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026B0 File Offset: 0x000008B0
		private async void box()
		{
			bool flag = this.gunaTextBox4.Text == "a";
			if (flag)
			{
				this.gunaTextBox4.Enabled = false;
				await this.Wait(200);
				this.gunaTextBox4.Enabled = true;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaShadowPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel3_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel4_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000026EF File Offset: 0x000008EF
		private void gunaLabel18_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel9_Click(this, new EventArgs());
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel58_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000026FF File Offset: 0x000008FF
		private void gunaImageCheckBox1_Click(object sender, EventArgs e)
		{
			this.gunaLabel33.Text = "combat";
			this.tabControl1.SelectTab("tabPage1");
			this.tab();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000272B File Offset: 0x0000092B
		private void gunaImageCheckBox2_Click(object sender, EventArgs e)
		{
			this.gunaLabel33.Text = "movement";
			this.tabControl1.SelectTab("tabPage2");
			this.tab();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaImageCheckBox3_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002757 File Offset: 0x00000957
		private void gunaImageCheckBox3_Click(object sender, EventArgs e)
		{
			this.gunaLabel33.Text = "more";
			this.tabControl1.SelectTab("tabPage3");
			this.tab();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000026EC File Offset: 0x000008EC
		private void tabPage2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaLabel55_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaAdvenceButton26_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002783 File Offset: 0x00000983
		private void gunaLabel62_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel13_Click(this, new EventArgs());
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002794 File Offset: 0x00000994
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.gunaLabel39.Text = this.bunifuSlider11.Value + ".0";
			this.gunaLabel38.Text = this.bunifuSlider10.Value + ".0";
			this.gunaLabel35.Text = this.bunifuSlider13.Value + ".0";
			this.gunaLabel34.Text = this.bunifuSlider12.Value + ".0";
			try
			{
				bool flag = this.bunifuSlider11.Value > this.bunifuSlider10.Value;
				if (flag)
				{
					this.bunifuSlider11.Value = this.bunifuSlider10.Value;
				}
				bool flag2 = this.bunifuSlider13.Value > this.bunifuSlider12.Value;
				if (flag2)
				{
					this.bunifuSlider13.Value = this.bunifuSlider12.Value;
				}
			}
			catch
			{
			}
			this.gunaLabel10.Text = this.bunifuSlider1.Value + ".0";
			this.gunaLabel11.Text = this.bunifuSlider2.Value + ".0";
			bool flag3 = this.bunifuSlider1.Value > this.bunifuSlider2.Value;
			if (flag3)
			{
				this.bunifuSlider1.Value = this.bunifuSlider2.Value;
			}
			this.gunaLabel20.Text = this.bunifuSlider4.Value + ".0";
			this.gunaLabel19.Text = this.bunifuSlider3.Value + ".0";
			bool flag4 = this.bunifuSlider6.Value == 0;
			if (flag4)
			{
				this.gunaLabel4.Text = "3.0";
			}
			else
			{
				bool flag5 = this.bunifuSlider6.Value == 1;
				if (flag5)
				{
					this.gunaLabel4.Text = "3.1";
				}
				else
				{
					bool flag6 = this.bunifuSlider6.Value == 2;
					if (flag6)
					{
						this.gunaLabel4.Text = "3.2";
					}
					else
					{
						bool flag7 = this.bunifuSlider6.Value == 3;
						if (flag7)
						{
							this.gunaLabel4.Text = "3.3";
						}
						else
						{
							bool flag8 = this.bunifuSlider6.Value == 4;
							if (flag8)
							{
								this.gunaLabel4.Text = "3.4";
							}
							else
							{
								bool flag9 = this.bunifuSlider6.Value == 5;
								if (flag9)
								{
									this.gunaLabel4.Text = "3.5";
								}
								else
								{
									bool flag10 = this.bunifuSlider6.Value == 6;
									if (flag10)
									{
										this.gunaLabel4.Text = "3.6";
									}
									else
									{
										bool flag11 = this.bunifuSlider6.Value == 7;
										if (flag11)
										{
											this.gunaLabel4.Text = "3.7";
										}
										else
										{
											bool flag12 = this.bunifuSlider6.Value == 8;
											if (flag12)
											{
												this.gunaLabel4.Text = "3.8";
											}
											else
											{
												bool flag13 = this.bunifuSlider6.Value == 9;
												if (flag13)
												{
													this.gunaLabel4.Text = "3.9";
												}
												else
												{
													bool flag14 = this.bunifuSlider6.Value == 10;
													if (flag14)
													{
														this.gunaLabel4.Text = "4.0";
													}
													else
													{
														bool flag15 = this.bunifuSlider6.Value == 11;
														if (flag15)
														{
															this.gunaLabel4.Text = "4.1";
														}
														else
														{
															bool flag16 = this.bunifuSlider6.Value == 12;
															if (flag16)
															{
																this.gunaLabel4.Text = "4.2";
															}
															else
															{
																bool flag17 = this.bunifuSlider6.Value == 13;
																if (flag17)
																{
																	this.gunaLabel4.Text = "4.3";
																}
																else
																{
																	bool flag18 = this.bunifuSlider6.Value == 14;
																	if (flag18)
																	{
																		this.gunaLabel4.Text = "4.4";
																	}
																	else
																	{
																		bool flag19 = this.bunifuSlider6.Value == 15;
																		if (flag19)
																		{
																			this.gunaLabel4.Text = "4.5";
																		}
																		else
																		{
																			bool flag20 = this.bunifuSlider6.Value == 16;
																			if (flag20)
																			{
																				this.gunaLabel4.Text = "4.6";
																			}
																			else
																			{
																				bool flag21 = this.bunifuSlider6.Value == 17;
																				if (flag21)
																				{
																					this.gunaLabel4.Text = "4.7";
																				}
																				else
																				{
																					bool flag22 = this.bunifuSlider6.Value == 18;
																					if (flag22)
																					{
																						this.gunaLabel4.Text = "4.8";
																					}
																					else
																					{
																						bool flag23 = this.bunifuSlider6.Value == 19;
																						if (flag23)
																						{
																							this.gunaLabel4.Text = "4.9";
																						}
																						else
																						{
																							bool flag24 = this.bunifuSlider6.Value == 20;
																							if (flag24)
																							{
																								this.gunaLabel4.Text = "5.0";
																							}
																							else
																							{
																								bool flag25 = this.bunifuSlider6.Value == 21;
																								if (flag25)
																								{
																									this.gunaLabel4.Text = "5.1";
																								}
																								else
																								{
																									bool flag26 = this.bunifuSlider6.Value == 22;
																									if (flag26)
																									{
																										this.gunaLabel4.Text = "5.2";
																									}
																									else
																									{
																										bool flag27 = this.bunifuSlider6.Value == 23;
																										if (flag27)
																										{
																											this.gunaLabel4.Text = "5.3";
																										}
																										else
																										{
																											bool flag28 = this.bunifuSlider6.Value == 24;
																											if (flag28)
																											{
																												this.gunaLabel4.Text = "5.4";
																											}
																											else
																											{
																												bool flag29 = this.bunifuSlider6.Value == 25;
																												if (flag29)
																												{
																													this.gunaLabel4.Text = "5.5";
																												}
																												else
																												{
																													bool flag30 = this.bunifuSlider6.Value == 26;
																													if (flag30)
																													{
																														this.gunaLabel4.Text = "5.6";
																													}
																													else
																													{
																														bool flag31 = this.bunifuSlider6.Value == 27;
																														if (flag31)
																														{
																															this.gunaLabel4.Text = "5.7";
																														}
																														else
																														{
																															bool flag32 = this.bunifuSlider6.Value == 28;
																															if (flag32)
																															{
																																this.gunaLabel4.Text = "5.8";
																															}
																															else
																															{
																																bool flag33 = this.bunifuSlider6.Value == 29;
																																if (flag33)
																																{
																																	this.gunaLabel4.Text = "5.9";
																																}
																																else
																																{
																																	bool flag34 = this.bunifuSlider6.Value == 30;
																																	if (flag34)
																																	{
																																		this.gunaLabel4.Text = "6.0";
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			this.gunaLabel3.Text = this.bunifuSlider5.Value + "%";
			this.gunaLabel5.Text = this.bunifuSlider8.Value + "%";
			this.gunaLabel29.Text = this.bunifuSlider9.Value + "%";
			this.gunaLabel2.Text = this.bunifuSlider7.Value + "%";
			bool flag35 = this.bunifuSlider4.Value > this.bunifuSlider3.Value;
			if (flag35)
			{
				this.bunifuSlider4.Value = this.bunifuSlider3.Value;
			}
			bool flag36 = this.bunifuSlider8.Value > this.bunifuSlider9.Value;
			if (flag36)
			{
				this.bunifuSlider8.Value = this.bunifuSlider9.Value;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002FEC File Offset: 0x000011EC
		private void gunaTextBox4_TextChanged(object sender, EventArgs e)
		{
			this.box();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaTextBox4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002FF8 File Offset: 0x000011F8
		private void gunaAdvenceButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton1.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton1.Text = "Disable";
				this.gunaAdvenceButton1.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton1.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.AutoClicker.Start();
			}
			else
			{
				this.gunaAdvenceButton1.Text = "Enable";
				this.gunaAdvenceButton1.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton1.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.AutoClicker.Stop();
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaLabel23_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000030B4 File Offset: 0x000012B4
		private void timer2_Tick(object sender, EventArgs e)
		{
			Dictionary<string, Keys> dictionary = new Dictionary<string, Keys>();
			dictionary.Add("A", Keys.A);
			dictionary.Add("B", Keys.B);
			dictionary.Add("C", Keys.C);
			dictionary.Add("D", Keys.D);
			dictionary.Add("E", Keys.E);
			dictionary.Add("F", Keys.F);
			dictionary.Add("G", Keys.G);
			dictionary.Add("H", Keys.H);
			dictionary.Add("I", Keys.I);
			dictionary.Add("J", Keys.J);
			dictionary.Add("K", Keys.K);
			dictionary.Add("L", Keys.L);
			dictionary.Add("M", Keys.M);
			dictionary.Add("N", Keys.N);
			dictionary.Add("O", Keys.O);
			dictionary.Add("P", Keys.P);
			dictionary.Add("Q", Keys.Q);
			dictionary.Add("R", Keys.R);
			dictionary.Add("S", Keys.S);
			dictionary.Add("T", Keys.T);
			dictionary.Add("U", Keys.U);
			dictionary.Add("V", Keys.V);
			dictionary.Add("W", Keys.W);
			dictionary.Add("X", Keys.X);
			dictionary.Add("Y", Keys.Y);
			dictionary.Add("Z", Keys.Z);
			dictionary.Add("a", Keys.A);
			dictionary.Add("b", Keys.B);
			dictionary.Add("c", Keys.C);
			dictionary.Add("d", Keys.D);
			dictionary.Add("e", Keys.E);
			dictionary.Add("f", Keys.F);
			dictionary.Add("g", Keys.G);
			dictionary.Add("h", Keys.H);
			dictionary.Add("i", Keys.I);
			dictionary.Add("j", Keys.J);
			dictionary.Add("k", Keys.K);
			dictionary.Add("l", Keys.L);
			dictionary.Add("m", Keys.M);
			dictionary.Add("n", Keys.N);
			dictionary.Add("o", Keys.O);
			dictionary.Add("p", Keys.P);
			dictionary.Add("q", Keys.Q);
			dictionary.Add("r", Keys.R);
			dictionary.Add("s", Keys.S);
			dictionary.Add("t", Keys.T);
			dictionary.Add("u", Keys.U);
			dictionary.Add("v", Keys.V);
			dictionary.Add("w", Keys.W);
			dictionary.Add("x", Keys.X);
			dictionary.Add("y", Keys.Y);
			dictionary.Add("z", Keys.Z);
			dictionary.Add("R-SHIFT", Keys.RShiftKey);
			dictionary.Add("F1", Keys.F1);
			dictionary.Add("F2", Keys.F2);
			dictionary.Add("F3", Keys.F3);
			dictionary.Add("F4", Keys.F4);
			dictionary.Add("F5", Keys.F5);
			dictionary.Add("F7", Keys.F7);
			dictionary.Add("F8", Keys.F8);
			dictionary.Add("F9", Keys.F9);
			dictionary.Add("F10", Keys.F10);
			dictionary.Add("F11", Keys.F11);
			dictionary.Add("F12", Keys.F12);
			dictionary.Add("f1", Keys.F1);
			dictionary.Add("f2", Keys.F2);
			dictionary.Add("f3", Keys.F3);
			dictionary.Add("f4", Keys.F4);
			dictionary.Add("f5", Keys.F5);
			dictionary.Add("f7", Keys.F7);
			dictionary.Add("f8", Keys.F8);
			dictionary.Add("f9", Keys.F9);
			dictionary.Add("f10", Keys.F10);
			dictionary.Add("f11", Keys.F11);
			dictionary.Add("f12", Keys.F12);
			dictionary.Add("", Keys.None);
			dictionary.Add("alt", Keys.Alt);
			dictionary.Add("ALT", Keys.Alt);
			dictionary.Add("INSERT", Keys.Insert);
			dictionary.Add("RButton", Keys.RButton);
			string text = this.gunaTextBox5.Text;
			try
			{
				bool flag = Form1.GetAsyncKeyState((int)dictionary[this.gunaTextBox4.Text]) != 0;
				if (flag)
				{
					Form1 form = new Form1();
					this.gunaAdvenceButton5_Click(this, new EventArgs());
					this.gunaTextBox4.Enabled = false;
					this.gunaTextBox4.Enabled = true;
				}
				else
				{
					bool flag2 = Form1.GetAsyncKeyState((int)dictionary[text]) != 0;
					if (flag2)
					{
						Form1 form2 = new Form1();
						this.gunaAdvenceButton1_Click(this, new EventArgs());
						this.gunaTextBox5.Enabled = false;
						this.gunaTextBox5.Enabled = true;
					}
					else
					{
						bool flag3 = Form1.GetAsyncKeyState((int)dictionary[this.gunaTextBox6.Text]) != 0;
						if (flag3)
						{
							Form1 form3 = new Form1();
							this.gunaAdvenceButton12_Click(this, new EventArgs());
							this.gunaTextBox6.Enabled = false;
							this.gunaTextBox6.Enabled = true;
						}
						else
						{
							bool flag4 = Form1.GetAsyncKeyState((int)dictionary[this.gunaTextBox7.Text]) != 0;
							if (flag4)
							{
								Form1 form4 = new Form1();
								this.gunaAdvenceButton16_Click(this, new EventArgs());
								this.gunaTextBox7.Enabled = false;
								this.gunaTextBox7.Enabled = true;
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000036A0 File Offset: 0x000018A0
		private void gunaAdvenceButton5_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton5.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton5.Text = "Disable";
				this.gunaAdvenceButton5.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton5.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.RIGHTCLICKER.Start();
			}
			else
			{
				this.gunaAdvenceButton5.Text = "Enable";
				this.gunaAdvenceButton5.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton5.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.RIGHTCLICKER.Stop();
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000375C File Offset: 0x0000195C
		private void gunaAdvenceButton12_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton12.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton12.Text = "Disable";
				this.gunaAdvenceButton12.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton12.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaAdvenceButton12.Text = "Enable";
				this.gunaAdvenceButton12.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton12.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003800 File Offset: 0x00001A00
		private void gunaAdvenceButton16_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton16.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton16.Text = "Disable";
				this.gunaAdvenceButton16.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton16.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaAdvenceButton16.Text = "Enable";
				this.gunaAdvenceButton16.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton16.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000038A4 File Offset: 0x00001AA4
		private void gunaAdvenceButton17_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton17.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton17.Text = "Disable";
				this.gunaAdvenceButton17.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton17.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.AUTOBLOCK.Start();
			}
			else
			{
				this.gunaAdvenceButton17.Text = "Enable";
				this.gunaAdvenceButton17.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton17.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.AUTOBLOCK.Stop();
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003960 File Offset: 0x00001B60
		private void gunaAdvenceButton18_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton18.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton18.Text = "Disable";
				this.gunaAdvenceButton18.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton18.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaAdvenceButton18.Text = "Enable";
				this.gunaAdvenceButton18.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton18.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003A04 File Offset: 0x00001C04
		private void timer3_Tick(object sender, EventArgs e)
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				bool flag2 = this.gunaAdvenceButton20.Text == "Disable";
				if (flag2)
				{
					try
					{
						this.WTAP.Interval = this.rnd.Next(this.bunifuSlider11.Value, this.bunifuSlider10.Value);
						InputHelper.SetKeyState(Keys.W, true);
						this.Delay(0.025);
						InputHelper.SetKeyState(Keys.W, false);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003B1C File Offset: 0x00001D1C
		private void AutoClicker_Tick(object sender, EventArgs e)
		{
			Random random = new Random();
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				int maxValue = (int)Math.Round(1000.0 / ((double)this.bunifuSlider1.Value + (double)this.bunifuSlider2.Value * 0.2));
				int minValue = (int)Math.Round(1000.0 / ((double)this.bunifuSlider1.Value + (double)this.bunifuSlider2.Value * 0.4));
				try
				{
					this.AutoClicker.Interval = random.Next(minValue, maxValue);
				}
				catch
				{
				}
				bool flag2 = Control.MouseButtons == MouseButtons.Left;
				bool flag3 = flag2;
				if (flag3)
				{
					Form1.mouse_event(4, 0, 0, 0, 0);
					Form1.mouse_event(2, 0, 0, 0, 0);
				}
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003C80 File Offset: 0x00001E80
		private void gunaAdvenceButton20_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton20.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton20.Text = "Disable";
				this.gunaAdvenceButton20.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton20.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton21.Text = "Enable";
				this.gunaAdvenceButton21.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton21.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.WTAP.Start();
			}
			else
			{
				this.gunaAdvenceButton20.Text = "Enable";
				this.gunaAdvenceButton20.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton20.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.WTAP.Stop();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003D78 File Offset: 0x00001F78
		private void timer4_Tick(object sender, EventArgs e)
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				bool flag2 = this.gunaAdvenceButton19.Text == "Disable";
				if (flag2)
				{
					try
					{
						this.STAP.Interval = this.rnd.Next(this.bunifuSlider11.Value, this.bunifuSlider10.Value);
						InputHelper.SetKeyState(Keys.S, true);
						this.Delay(0.025);
						InputHelper.SetKeyState(Keys.S, false);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaLabel34_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003E90 File Offset: 0x00002090
		private void gunaAdvenceButton19_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton19.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton19.Text = "Disable";
				this.gunaAdvenceButton19.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton19.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.STAP.Start();
			}
			else
			{
				this.gunaAdvenceButton19.Text = "Enable";
				this.gunaAdvenceButton19.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton19.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.STAP.Stop();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003F4C File Offset: 0x0000214C
		private void gunaAdvenceButton21_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton21.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton21.Text = "Disable";
				this.gunaAdvenceButton21.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton21.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton20.Text = "Enable";
				this.gunaAdvenceButton20.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton20.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.SPRINT.Start();
			}
			else
			{
				this.gunaAdvenceButton21.Text = "Enable";
				this.gunaAdvenceButton21.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton21.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.SPRINT.Stop();
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004044 File Offset: 0x00002244
		private void SPRINT_Tick(object sender, EventArgs e)
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				bool flag2 = this.gunaAdvenceButton21.Text == "Disable";
				if (flag2)
				{
					Dictionary<string, Keys> dictionary = new Dictionary<string, Keys>();
					dictionary.Add("W", Keys.W);
					string text = this.gunaTextBox8.Text;
					bool flag3 = Form1.GetAsyncKeyState((int)dictionary[text]) != 0;
					if (flag3)
					{
						InputHelper.SetKeyState(Keys.LControlKey, true);
						this.Delay(0.01);
						InputHelper.SetKeyState(Keys.LControlKey, false);
					}
					else
					{
						InputHelper.SetKeyState(Keys.LControlKey, true);
					}
				}
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaTextBox8_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel84_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004164 File Offset: 0x00002364
		private void gunaAdvenceButton23_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton23.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton23.Text = "Disable";
				this.gunaAdvenceButton23.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton23.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.het();
				this.ANTIAFK.Start();
			}
			else
			{
				this.gunaAdvenceButton23.Text = "Enable";
				this.gunaAdvenceButton23.BaseColor = Color.FromArgb(8, 8, 8);
				this.gunaAdvenceButton23.OnHoverBaseColor = Color.FromArgb(8, 8, 8);
				this.gunaLabel52.ForeColor = Color.Silver;
				this.ANTIAFK.Stop();
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004238 File Offset: 0x00002438
		private void ANTIAFK_Tick(object sender, EventArgs e)
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				InputHelper.SetKeyState(Keys.Space, true);
				this.Delay(0.025);
				InputHelper.SetKeyState(Keys.Space, false);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000042ED File Offset: 0x000024ED
		private void macmelt_Tick(object sender, EventArgs e)
		{
			InputHelper.SetKeyState(Keys.F, true);
			this.Delay(0.025);
			InputHelper.SetKeyState(Keys.F, false);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004314 File Offset: 0x00002514
		private async void save()
		{
			this.gunaLabel70.Text = "SAVED";
			this.gunaPanel142.Show();
			await this.Wait(1000);
			this.gunaPanel142.Hide();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004350 File Offset: 0x00002550
		private async void reset()
		{
			this.gunaLabel70.Text = "RESETED";
			this.gunaPanel142.Show();
			await this.Wait(1000);
			this.gunaPanel142.Hide();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000438C File Offset: 0x0000258C
		private async void legit()
		{
			this.gunaLabel70.Text = "LEGIT SETED";
			this.gunaPanel142.Show();
			await this.Wait(1000);
			this.gunaPanel142.Hide();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000043C8 File Offset: 0x000025C8
		private async void blatant()
		{
			this.gunaLabel70.Text = "BLATANT SETED";
			this.gunaPanel142.Show();
			await this.Wait(1000);
			this.gunaPanel142.Hide();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004404 File Offset: 0x00002604
		private void gunaAdvenceButton7_Click(object sender, EventArgs e)
		{
			this.save();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004410 File Offset: 0x00002610
		private void gunaAdvenceButton8_Click(object sender, EventArgs e)
		{
			this.reset();
			this.bunifuSlider1.Value = 0;
			this.bunifuSlider2.Value = 0;
			this.bunifuSlider3.Value = 0;
			this.bunifuSlider4.Value = 0;
			this.bunifuSlider5.Value = 0;
			this.bunifuSlider6.Value = 0;
			this.bunifuSlider7.Value = 0;
			this.bunifuSlider8.Value = 0;
			this.bunifuSlider9.Value = 0;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000449C File Offset: 0x0000269C
		private void gunaAdvenceButton13_Click(object sender, EventArgs e)
		{
			this.legit();
			this.bunifuSlider1.Value = 12;
			this.bunifuSlider2.Value = 14;
			this.bunifuSlider4.Value = 10;
			this.bunifuSlider3.Value = 25;
			this.bunifuSlider6.Value = 2;
			this.bunifuSlider5.Value = 75;
			this.bunifuSlider8.Value = 25;
			this.bunifuSlider9.Value = 42;
			this.bunifuSlider7.Value = 92;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004530 File Offset: 0x00002730
		private void gunaAdvenceButton14_Click(object sender, EventArgs e)
		{
			this.blatant();
			this.bunifuSlider1.Value = 15;
			this.bunifuSlider2.Value = 20;
			this.bunifuSlider4.Value = 10;
			this.bunifuSlider3.Value = 25;
			this.bunifuSlider6.Value = 7;
			this.bunifuSlider5.Value = 50;
			this.bunifuSlider8.Value = 40;
			this.bunifuSlider9.Value = 80;
			this.bunifuSlider7.Value = 45;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000045C4 File Offset: 0x000027C4
		private void RIGHTCLICKER_Tick(object sender, EventArgs e)
		{
			Random random = new Random();
			int mouseButtons = (int)Control.MouseButtons;
			int maxValue = (int)Math.Round(1000.0 / ((double)this.bunifuSlider4.Value + (double)this.bunifuSlider3.Value * 0.2));
			int minValue = (int)Math.Round(1000.0 / ((double)this.bunifuSlider4.Value + (double)this.bunifuSlider3.Value * 0.4));
			try
			{
				this.RIGHTCLICKER.Interval = random.Next(minValue, maxValue);
			}
			catch
			{
			}
			bool flag = Control.MouseButtons == MouseButtons.Right;
			if (flag)
			{
				Form1.mouse_event(16, 0, 0, 0, 0);
				Form1.mouse_event(8, 0, 0, 0, 0);
			}
			else
			{
				int mouseButtons2 = (int)Control.MouseButtons;
				bool flag2 = Control.MouseButtons == MouseButtons.Right;
				if (flag2)
				{
					Form1.mouse_event(4, 0, 0, 0, 0);
					Form1.mouse_event(2, 0, 0, 0, 0);
				}
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000046D4 File Offset: 0x000028D4
		private void timer3_Tick_1(object sender, EventArgs e)
		{
			bool flag = Control.MouseButtons == MouseButtons.Right;
			if (flag)
			{
				Form1.mouse_event(16, 0, 0, 0, 0);
				Form1.mouse_event(8, 0, 0, 0, 0);
			}
			else
			{
				int mouseButtons = (int)Control.MouseButtons;
				bool flag2 = Control.MouseButtons == MouseButtons.Right;
				if (flag2)
				{
					Form1.mouse_event(4, 0, 0, 0, 0);
					Form1.mouse_event(2, 0, 0, 0, 0);
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004740 File Offset: 0x00002940
		private void gunaAdvenceButton2_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaAdvenceButton2.Text == "Enable";
			if (flag)
			{
				this.gunaAdvenceButton2.Text = "Disable";
				this.gunaAdvenceButton2.BaseColor = Color.FromArgb(80, 2, 100);
				this.gunaAdvenceButton2.OnHoverBaseColor = Color.FromArgb(80, 2, 100);
				this.timer3.Start();
			}
			else
			{
				this.gunaAdvenceButton2.Text = "Enable";
				this.gunaAdvenceButton2.BaseColor = Color.FromArgb(8, 8, 8);
				this.timer3.Stop();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000047E8 File Offset: 0x000029E8
		private void gunaShadowPanel2_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel73.Text == "oi";
			if (flag)
			{
				this.gunaLabel73.Text = "";
				this.gunaShadowPanel2.BaseColor = Color.FromArgb(80, 2, 100);
				this.CSPRINT.Start();
			}
			else
			{
				this.gunaLabel73.Text = "oi";
				this.gunaShadowPanel2.BaseColor = Color.FromArgb(15, 15, 15);
				this.CSPRINT.Stop();
				bool flag2 = this.gunaAdvenceButton1.Text == "Disable";
				if (flag2)
				{
					this.AutoClicker.Start();
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000048A4 File Offset: 0x00002AA4
		private void gunaShadowPanel3_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel74.Text == "oi";
			if (flag)
			{
				this.gunaLabel74.Text = "";
				this.gunaShadowPanel3.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel74.Text = "oi";
				this.gunaShadowPanel3.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004920 File Offset: 0x00002B20
		private void gunaShadowPanel4_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel75.Text == "oi";
			if (flag)
			{
				this.gunaLabel75.Text = "";
				this.gunaShadowPanel4.BaseColor = Color.FromArgb(80, 2, 100);
				this.STOPAC.Start();
			}
			else
			{
				this.gunaLabel75.Text = "oi";
				this.gunaShadowPanel4.BaseColor = Color.FromArgb(15, 15, 15);
				this.STOPAC.Stop();
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000049B4 File Offset: 0x00002BB4
		private void gunaShadowPanel5_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel76.Text == "oi";
			if (flag)
			{
				this.gunaLabel76.Text = "";
				this.gunaShadowPanel5.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel76.Text = "oi";
				this.gunaShadowPanel5.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004A30 File Offset: 0x00002C30
		private void gunaShadowPanel9_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel78.Text == "oi";
			if (flag)
			{
				this.gunaLabel78.Text = "";
				this.gunaShadowPanel9.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel78.Text = "oi";
				this.gunaShadowPanel9.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004AAC File Offset: 0x00002CAC
		private void gunaShadowPanel6_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel79.Text == "oi";
			if (flag)
			{
				this.gunaLabel79.Text = "";
				this.gunaShadowPanel6.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel79.Text = "oi";
				this.gunaShadowPanel6.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaLabel79_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004B28 File Offset: 0x00002D28
		private void gunaShadowPanel7_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel80.Text == "oi";
			if (flag)
			{
				this.gunaLabel80.Text = "";
				this.gunaShadowPanel7.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel80.Text = "oi";
				this.gunaShadowPanel7.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004BA4 File Offset: 0x00002DA4
		private void gunaShadowPanel17_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel81.Text == "oi";
			if (flag)
			{
				this.gunaLabel81.Text = "";
				this.gunaShadowPanel17.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel81.Text = "oi";
				this.gunaShadowPanel17.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004C20 File Offset: 0x00002E20
		private async void stopac()
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				bool flag2 = this.gunaAdvenceButton1.Text == "Disable";
				if (flag2)
				{
					bool flag3 = this.gunaShadowPanel4.BaseColor == Color.FromArgb(80, 2, 100);
					if (flag3)
					{
						Dictionary<string, Keys> dictionary = new Dictionary<string, Keys>();
						dictionary.Add("W", Keys.E);
						string bind = this.gunaTextBox8.Text;
						bool flag4 = Form1.GetAsyncKeyState((int)dictionary[bind]) != 0;
						if (flag4)
						{
							this.AutoClicker.Stop();
							await this.Wait(2500);
							this.AutoClicker.Start();
						}
						dictionary = null;
						bind = null;
					}
				}
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004C5C File Offset: 0x00002E5C
		private async void stoperight()
		{
			bool flag = this.gunaShadowPanel9.BaseColor == Color.FromArgb(80, 2, 100);
			if (flag)
			{
				Dictionary<string, Keys> dictionary = new Dictionary<string, Keys>();
				dictionary.Add("W", Keys.E);
				string bind = this.gunaTextBox8.Text;
				bool flag2 = Form1.GetAsyncKeyState((int)dictionary[bind]) != 0;
				if (flag2)
				{
					this.RIGHTCLICKER.Stop();
					await this.Wait(2500);
					this.RIGHTCLICKER.Start();
				}
				dictionary = null;
				bind = null;
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004C98 File Offset: 0x00002E98
		private void STOPAC_Tick(object sender, EventArgs e)
		{
			this.stopac();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004CA2 File Offset: 0x00002EA2
		private void Form1_Load(object sender, EventArgs e)
		{
			this.STOPAC.Start();
			this.timer1.Start();
			this.timer2.Start();
			this.STOPAC.Start();
			this.CSPRINT.Start();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004CE4 File Offset: 0x00002EE4
		private void gunaShadowPanel12_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel82.Text == "oi";
			if (flag)
			{
				this.gunaLabel82.Text = "";
				this.gunaShadowPanel12.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel82.Text = "oi";
				this.gunaShadowPanel12.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaShadowPanel16_ClientSizeChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004D60 File Offset: 0x00002F60
		private void gunaShadowPanel16_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel83.Text == "oi";
			if (flag)
			{
				this.gunaLabel83.Text = "";
				this.gunaShadowPanel16.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel83.Text = "oi";
				this.gunaShadowPanel16.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004DDC File Offset: 0x00002FDC
		private void gunaShadowPanel13_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel84.Text == "oi";
			if (flag)
			{
				this.gunaLabel84.Text = "";
				this.gunaShadowPanel13.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel84.Text = "oi";
				this.gunaShadowPanel13.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004E58 File Offset: 0x00003058
		private void gunaShadowPanel14_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel85.Text == "oi";
			if (flag)
			{
				this.gunaLabel85.Text = "";
				this.gunaShadowPanel14.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel85.Text = "oi";
				this.gunaShadowPanel14.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004ED4 File Offset: 0x000030D4
		private void gunaShadowPanel15_Click(object sender, EventArgs e)
		{
			bool flag = this.gunaLabel86.Text == "oi";
			if (flag)
			{
				this.gunaLabel86.Text = "";
				this.gunaShadowPanel15.BaseColor = Color.FromArgb(80, 2, 100);
			}
			else
			{
				this.gunaLabel86.Text = "oi";
				this.gunaShadowPanel15.BaseColor = Color.FromArgb(15, 15, 15);
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004F50 File Offset: 0x00003150
		private void gunaLabel12_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel2_Click(this, new EventArgs());
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004F60 File Offset: 0x00003160
		private void gunaLabel13_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel3_Click(this, new EventArgs());
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004F70 File Offset: 0x00003170
		private void gunaLabel14_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel4_Click(this, new EventArgs());
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004F80 File Offset: 0x00003180
		private void gunaLabel15_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel5_Click(this, new EventArgs());
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004F90 File Offset: 0x00003190
		private void gunaLabel30_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel6_Click(this, new EventArgs());
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004FA0 File Offset: 0x000031A0
		private void gunaLabel44_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel7_Click(this, new EventArgs());
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004FB0 File Offset: 0x000031B0
		private void gunaLabel71_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel17_Click(this, new EventArgs());
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaLabel45_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004FC0 File Offset: 0x000031C0
		private void gunaLabel65_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel15_Click(this, new EventArgs());
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004FD0 File Offset: 0x000031D0
		private void gunaLabel67_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel16_Click(this, new EventArgs());
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004FE0 File Offset: 0x000031E0
		private void gunaLabel60_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel12_Click(this, new EventArgs());
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004FF0 File Offset: 0x000031F0
		private void gunaLabel64_Click(object sender, EventArgs e)
		{
			this.gunaShadowPanel14_Click(this, new EventArgs());
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005000 File Offset: 0x00003200
		private async void cprint()
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				bool flag2 = this.gunaAdvenceButton1.Text == "Disable";
				if (flag2)
				{
					bool flag3 = this.gunaShadowPanel2.BaseColor == Color.FromArgb(80, 2, 100);
					if (flag3)
					{
						Dictionary<string, Keys> dictionary = new Dictionary<string, Keys>();
						dictionary.Add("W", Keys.LControlKey);
						string bind = this.gunaTextBox8.Text;
						bool flag4 = Form1.GetAsyncKeyState((int)dictionary[bind]) != 0;
						if (flag4)
						{
							this.AutoClicker.Start();
						}
						else
						{
							this.AutoClicker.Stop();
						}
						dictionary = null;
						bind = null;
					}
				}
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000503C File Offset: 0x0000323C
		private void CSPRINT_Tick(object sender, EventArgs e)
		{
			this.cprint();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaGradientTileButton1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel150_MouseMove(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel150_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000026EC File Offset: 0x000008EC
		private void gunaPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005048 File Offset: 0x00003248
		private void AUTOBLOCK_Tick(object sender, EventArgs e)
		{
			bool flag = this.GetCaptionOfActiveWindow().Contains("Minecraft") || this.GetCaptionOfActiveWindow().Contains("Badlion") || this.GetCaptionOfActiveWindow().Contains("Labymod") || this.GetCaptionOfActiveWindow().Contains("OCMC") || this.GetCaptionOfActiveWindow().Contains("Cheatbreaker") || this.GetCaptionOfActiveWindow().Contains("J3Ultimate") || this.GetCaptionOfActiveWindow().Contains("LunarClient");
			if (flag)
			{
				bool flag2 = this.gunaAdvenceButton17.Text == "Disable";
				if (flag2)
				{
					InputHelper.SetKeyState(Keys.RButton, true);
					this.Delay(0.025);
					InputHelper.SetKeyState(Keys.RButton, false);
				}
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005118 File Offset: 0x00003318
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00005150 File Offset: 0x00003350
		private void InitializeComponent()
		{
			this.components = new Container();
			this.gunaShadowPanel1 = new GunaShadowPanel();
			this.gunaPanel61 = new GunaPanel();
			this.gunaPanel60 = new GunaPanel();
			this.gunaPanel59 = new GunaPanel();
			this.gunaPanel58 = new GunaPanel();
			this.tabControl1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.gunaPanel142 = new GunaPanel();
			this.gunaPanel144 = new GunaPanel();
			this.gunaLabel70 = new GunaLabel();
			this.gunaPanel3 = new GunaPanel();
			this.gunaLabel87 = new GunaLabel();
			this.gunaTextBox5 = new GunaTextBox();
			this.gunaLabel14 = new GunaLabel();
			this.gunaLabel15 = new GunaLabel();
			this.gunaLabel13 = new GunaLabel();
			this.gunaLabel12 = new GunaLabel();
			this.gunaAdvenceButton1 = new GunaAdvenceButton();
			this.gunaShadowPanel5 = new GunaShadowPanel();
			this.gunaShadowPanel3 = new GunaShadowPanel();
			this.gunaShadowPanel4 = new GunaShadowPanel();
			this.gunaPanel43 = new GunaPanel();
			this.gunaShadowPanel2 = new GunaShadowPanel();
			this.gunaLabel11 = new GunaLabel();
			this.gunaLabel10 = new GunaLabel();
			this.gunaPanel42 = new GunaPanel();
			this.gunaPanel40 = new GunaPanel();
			this.gunaPanel41 = new GunaPanel();
			this.gunaLabel9 = new GunaLabel();
			this.bunifuSlider2 = new BunifuSlider();
			this.gunaPanel39 = new GunaPanel();
			this.gunaLabel8 = new GunaLabel();
			this.bunifuSlider1 = new BunifuSlider();
			this.gunaLabel1 = new GunaLabel();
			this.gunaPanel9 = new GunaPanel();
			this.gunaPanel8 = new GunaPanel();
			this.gunaPanel7 = new GunaPanel();
			this.gunaPanel6 = new GunaPanel();
			this.gunaPanel4 = new GunaPanel();
			this.gunaLabel88 = new GunaLabel();
			this.gunaTextBox4 = new GunaTextBox();
			this.gunaLabel18 = new GunaLabel();
			this.gunaAdvenceButton3 = new GunaAdvenceButton();
			this.gunaAdvenceButton4 = new GunaAdvenceButton();
			this.gunaShadowPanel9 = new GunaShadowPanel();
			this.gunaLabel19 = new GunaLabel();
			this.gunaAdvenceButton5 = new GunaAdvenceButton();
			this.gunaLabel20 = new GunaLabel();
			this.gunaPanel11 = new GunaPanel();
			this.gunaPanel12 = new GunaPanel();
			this.gunaPanel13 = new GunaPanel();
			this.gunaLabel21 = new GunaLabel();
			this.gunaPanel10 = new GunaPanel();
			this.bunifuSlider3 = new BunifuSlider();
			this.gunaPanel44 = new GunaPanel();
			this.gunaLabel22 = new GunaLabel();
			this.bunifuSlider4 = new BunifuSlider();
			this.gunaLabel23 = new GunaLabel();
			this.gunaPanel45 = new GunaPanel();
			this.gunaPanel46 = new GunaPanel();
			this.gunaPanel47 = new GunaPanel();
			this.gunaPanel48 = new GunaPanel();
			this.gunaPanel14 = new GunaPanel();
			this.gunaLabel89 = new GunaLabel();
			this.gunaTextBox6 = new GunaTextBox();
			this.gunaAdvenceButton9 = new GunaAdvenceButton();
			this.gunaAdvenceButton10 = new GunaAdvenceButton();
			this.gunaLabel3 = new GunaLabel();
			this.gunaAdvenceButton12 = new GunaAdvenceButton();
			this.gunaLabel4 = new GunaLabel();
			this.gunaPanel15 = new GunaPanel();
			this.gunaPanel16 = new GunaPanel();
			this.gunaPanel17 = new GunaPanel();
			this.gunaLabel16 = new GunaLabel();
			this.gunaPanel18 = new GunaPanel();
			this.bunifuSlider5 = new BunifuSlider();
			this.gunaPanel19 = new GunaPanel();
			this.gunaLabel17 = new GunaLabel();
			this.bunifuSlider6 = new BunifuSlider();
			this.gunaLabel24 = new GunaLabel();
			this.gunaPanel20 = new GunaPanel();
			this.gunaPanel21 = new GunaPanel();
			this.gunaPanel22 = new GunaPanel();
			this.gunaPanel23 = new GunaPanel();
			this.gunaPanel29 = new GunaPanel();
			this.bunifuDropdown2 = new BunifuDropdown();
			this.gunaNumeric3 = new GunaNumeric();
			this.gunaAdvenceButton18 = new GunaAdvenceButton();
			this.gunaNumeric2 = new GunaNumeric();
			this.gunaNumeric1 = new GunaNumeric();
			this.gunaLabel32 = new GunaLabel();
			this.gunaLabel31 = new GunaLabel();
			this.gunaLabel6 = new GunaLabel();
			this.gunaPanel30 = new GunaPanel();
			this.gunaPanel31 = new GunaPanel();
			this.gunaPanel57 = new GunaPanel();
			this.gunaPanel32 = new GunaPanel();
			this.gunaPanel33 = new GunaPanel();
			this.gunaPanel24 = new GunaPanel();
			this.gunaLabel90 = new GunaLabel();
			this.gunaTextBox7 = new GunaTextBox();
			this.gunaLabel2 = new GunaLabel();
			this.gunaAdvenceButton16 = new GunaAdvenceButton();
			this.gunaLabel30 = new GunaLabel();
			this.gunaLabel29 = new GunaLabel();
			this.gunaLabel5 = new GunaLabel();
			this.gunaPanel25 = new GunaPanel();
			this.gunaPanel55 = new GunaPanel();
			this.gunaPanel26 = new GunaPanel();
			this.gunaPanel27 = new GunaPanel();
			this.gunaLabel25 = new GunaLabel();
			this.gunaPanel28 = new GunaPanel();
			this.gunaShadowPanel6 = new GunaShadowPanel();
			this.bunifuSlider7 = new BunifuSlider();
			this.gunaPanel54 = new GunaPanel();
			this.gunaLabel28 = new GunaLabel();
			this.bunifuSlider9 = new BunifuSlider();
			this.gunaPanel49 = new GunaPanel();
			this.gunaLabel26 = new GunaLabel();
			this.bunifuSlider8 = new BunifuSlider();
			this.gunaLabel27 = new GunaLabel();
			this.gunaPanel50 = new GunaPanel();
			this.gunaPanel51 = new GunaPanel();
			this.gunaPanel52 = new GunaPanel();
			this.gunaPanel53 = new GunaPanel();
			this.gunaPanel34 = new GunaPanel();
			this.bunifuDropdown1 = new BunifuDropdown();
			this.gunaLabel7 = new GunaLabel();
			this.gunaPanel35 = new GunaPanel();
			this.gunaPanel36 = new GunaPanel();
			this.gunaPanel37 = new GunaPanel();
			this.gunaPanel38 = new GunaPanel();
			this.gunaAdvenceButton17 = new GunaAdvenceButton();
			this.gunaPanel56 = new GunaPanel();
			this.gunaAdvenceButton7 = new GunaAdvenceButton();
			this.gunaAdvenceButton14 = new GunaAdvenceButton();
			this.gunaAdvenceButton8 = new GunaAdvenceButton();
			this.gunaAdvenceButton13 = new GunaAdvenceButton();
			this.tabPage2 = new TabPage();
			this.gunaTextBox9 = new GunaTextBox();
			this.gunaTextBox8 = new GunaTextBox();
			this.gunaPanel84 = new GunaPanel();
			this.gunaLabel45 = new GunaLabel();
			this.gunaShadowPanel8 = new GunaShadowPanel();
			this.gunaAdvenceButton22 = new GunaAdvenceButton();
			this.gunaPanel85 = new GunaPanel();
			this.gunaLabel46 = new GunaLabel();
			this.gunaPanel86 = new GunaPanel();
			this.gunaPanel87 = new GunaPanel();
			this.gunaPanel92 = new GunaPanel();
			this.gunaPanel93 = new GunaPanel();
			this.gunaPanel143 = new GunaPanel();
			this.gunaLabel71 = new GunaLabel();
			this.gunaShadowPanel17 = new GunaShadowPanel();
			this.gunaAdvenceButton2 = new GunaAdvenceButton();
			this.gunaPanel145 = new GunaPanel();
			this.gunaLabel72 = new GunaLabel();
			this.gunaPanel146 = new GunaPanel();
			this.gunaPanel147 = new GunaPanel();
			this.gunaPanel148 = new GunaPanel();
			this.gunaPanel149 = new GunaPanel();
			this.gunaPanel82 = new GunaPanel();
			this.gunaLabel44 = new GunaLabel();
			this.gunaShadowPanel7 = new GunaShadowPanel();
			this.gunaAdvenceButton21 = new GunaAdvenceButton();
			this.gunaPanel83 = new GunaPanel();
			this.gunaLabel48 = new GunaLabel();
			this.gunaPanel88 = new GunaPanel();
			this.gunaPanel89 = new GunaPanel();
			this.gunaPanel90 = new GunaPanel();
			this.gunaPanel91 = new GunaPanel();
			this.gunaPanel72 = new GunaPanel();
			this.gunaAdvenceButton19 = new GunaAdvenceButton();
			this.gunaPanel73 = new GunaPanel();
			this.gunaLabel34 = new GunaLabel();
			this.gunaLabel35 = new GunaLabel();
			this.gunaPanel74 = new GunaPanel();
			this.gunaPanel75 = new GunaPanel();
			this.gunaPanel76 = new GunaPanel();
			this.gunaLabel36 = new GunaLabel();
			this.bunifuSlider12 = new BunifuSlider();
			this.gunaPanel77 = new GunaPanel();
			this.gunaLabel37 = new GunaLabel();
			this.bunifuSlider13 = new BunifuSlider();
			this.gunaLabel43 = new GunaLabel();
			this.gunaPanel78 = new GunaPanel();
			this.gunaPanel79 = new GunaPanel();
			this.gunaPanel80 = new GunaPanel();
			this.gunaPanel81 = new GunaPanel();
			this.gunaPanel94 = new GunaPanel();
			this.gunaAdvenceButton23 = new GunaAdvenceButton();
			this.gunaPanel95 = new GunaPanel();
			this.gunaLabel47 = new GunaLabel();
			this.gunaLabel49 = new GunaLabel();
			this.gunaLabel52 = new GunaLabel();
			this.gunaPanel100 = new GunaPanel();
			this.gunaPanel101 = new GunaPanel();
			this.gunaPanel102 = new GunaPanel();
			this.gunaPanel103 = new GunaPanel();
			this.gunaPanel62 = new GunaPanel();
			this.gunaAdvenceButton20 = new GunaAdvenceButton();
			this.gunaPanel63 = new GunaPanel();
			this.gunaLabel38 = new GunaLabel();
			this.gunaLabel39 = new GunaLabel();
			this.gunaPanel64 = new GunaPanel();
			this.gunaPanel65 = new GunaPanel();
			this.gunaPanel66 = new GunaPanel();
			this.gunaLabel40 = new GunaLabel();
			this.bunifuSlider10 = new BunifuSlider();
			this.gunaPanel67 = new GunaPanel();
			this.gunaLabel41 = new GunaLabel();
			this.bunifuSlider11 = new BunifuSlider();
			this.gunaLabel42 = new GunaLabel();
			this.gunaPanel68 = new GunaPanel();
			this.gunaPanel69 = new GunaPanel();
			this.gunaPanel70 = new GunaPanel();
			this.gunaPanel71 = new GunaPanel();
			this.tabPage3 = new TabPage();
			this.gunaPanel98 = new GunaPanel();
			this.gunaLabel57 = new GunaLabel();
			this.gunaLabel56 = new GunaLabel();
			this.gunaShadowPanel11 = new GunaShadowPanel();
			this.gunaShadowPanel10 = new GunaShadowPanel();
			this.gunaLabel51 = new GunaLabel();
			this.gunaPanel99 = new GunaPanel();
			this.gunaPanel112 = new GunaPanel();
			this.gunaLabel54 = new GunaLabel();
			this.bunifuSlider14 = new BunifuSlider();
			this.gunaLabel53 = new GunaLabel();
			this.gunaPanel104 = new GunaPanel();
			this.gunaPanel105 = new GunaPanel();
			this.gunaPanel110 = new GunaPanel();
			this.gunaPanel111 = new GunaPanel();
			this.gunaPanel125 = new GunaPanel();
			this.gunaLabel64 = new GunaLabel();
			this.gunaLabel62 = new GunaLabel();
			this.gunaShadowPanel14 = new GunaShadowPanel();
			this.gunaShadowPanel13 = new GunaShadowPanel();
			this.gunaLabel63 = new GunaLabel();
			this.gunaPanel127 = new GunaPanel();
			this.gunaPanel128 = new GunaPanel();
			this.gunaPanel129 = new GunaPanel();
			this.gunaPanel130 = new GunaPanel();
			this.gunaPanel136 = new GunaPanel();
			this.gunaTextBox3 = new GunaTextBox();
			this.gunaLabel67 = new GunaLabel();
			this.gunaAdvenceButton31 = new GunaAdvenceButton();
			this.gunaLabel69 = new GunaLabel();
			this.gunaPanel137 = new GunaPanel();
			this.gunaShadowPanel16 = new GunaShadowPanel();
			this.gunaLabel68 = new GunaLabel();
			this.gunaPanel138 = new GunaPanel();
			this.gunaPanel139 = new GunaPanel();
			this.gunaPanel140 = new GunaPanel();
			this.gunaPanel141 = new GunaPanel();
			this.gunaPanel126 = new GunaPanel();
			this.gunaAdvenceButton28 = new GunaAdvenceButton();
			this.gunaLabel65 = new GunaLabel();
			this.gunaAdvenceButton29 = new GunaAdvenceButton();
			this.gunaPanel131 = new GunaPanel();
			this.gunaShadowPanel15 = new GunaShadowPanel();
			this.gunaLabel66 = new GunaLabel();
			this.gunaPanel132 = new GunaPanel();
			this.gunaPanel133 = new GunaPanel();
			this.gunaPanel134 = new GunaPanel();
			this.gunaPanel135 = new GunaPanel();
			this.gunaPanel119 = new GunaPanel();
			this.gunaAdvenceButton27 = new GunaAdvenceButton();
			this.gunaLabel60 = new GunaLabel();
			this.gunaAdvenceButton26 = new GunaAdvenceButton();
			this.gunaPanel120 = new GunaPanel();
			this.gunaShadowPanel12 = new GunaShadowPanel();
			this.gunaLabel61 = new GunaLabel();
			this.gunaPanel121 = new GunaPanel();
			this.gunaPanel122 = new GunaPanel();
			this.gunaPanel123 = new GunaPanel();
			this.gunaPanel124 = new GunaPanel();
			this.gunaPanel113 = new GunaPanel();
			this.gunaTextBox2 = new GunaTextBox();
			this.gunaAdvenceButton25 = new GunaAdvenceButton();
			this.gunaPanel114 = new GunaPanel();
			this.gunaLabel58 = new GunaLabel();
			this.gunaLabel59 = new GunaLabel();
			this.gunaPanel115 = new GunaPanel();
			this.gunaPanel116 = new GunaPanel();
			this.gunaPanel117 = new GunaPanel();
			this.gunaPanel118 = new GunaPanel();
			this.gunaPanel96 = new GunaPanel();
			this.gunaTextBox1 = new GunaTextBox();
			this.gunaAdvenceButton24 = new GunaAdvenceButton();
			this.gunaPanel97 = new GunaPanel();
			this.gunaLabel50 = new GunaLabel();
			this.gunaLabel55 = new GunaLabel();
			this.gunaPanel106 = new GunaPanel();
			this.gunaPanel107 = new GunaPanel();
			this.gunaPanel108 = new GunaPanel();
			this.gunaPanel109 = new GunaPanel();
			this.gunaPanel5 = new GunaPanel();
			this.gunaPanel2 = new GunaPanel();
			this.gunaPanel1 = new GunaPanel();
			this.gunaImageCheckBox3 = new GunaImageCheckBox();
			this.gunaImageCheckBox2 = new GunaImageCheckBox();
			this.gunaImageCheckBox1 = new GunaImageCheckBox();
			this.gunaLabel81 = new GunaLabel();
			this.gunaLabel80 = new GunaLabel();
			this.gunaLabel79 = new GunaLabel();
			this.gunaLabel78 = new GunaLabel();
			this.gunaLabel77 = new GunaLabel();
			this.gunaLabel76 = new GunaLabel();
			this.gunaLabel75 = new GunaLabel();
			this.gunaLabel86 = new GunaLabel();
			this.gunaLabel85 = new GunaLabel();
			this.gunaLabel83 = new GunaLabel();
			this.gunaLabel84 = new GunaLabel();
			this.gunaLabel82 = new GunaLabel();
			this.gunaLabel74 = new GunaLabel();
			this.gunaLabel73 = new GunaLabel();
			this.gunaLabel33 = new GunaLabel();
			this.timer1 = new Timer(this.components);
			this.timer2 = new Timer(this.components);
			this.WTAP = new Timer(this.components);
			this.AutoClicker = new Timer(this.components);
			this.STAP = new Timer(this.components);
			this.SPRINT = new Timer(this.components);
			this.ANTIAFK = new Timer(this.components);
			this.macmelt = new Timer(this.components);
			this.RIGHTCLICKER = new Timer(this.components);
			this.timer3 = new Timer(this.components);
			this.STOPAC = new Timer(this.components);
			this.CSPRINT = new Timer(this.components);
			this.AUTOBLOCK = new Timer(this.components);
			this.gunaShadowPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gunaPanel142.SuspendLayout();
			this.gunaPanel3.SuspendLayout();
			this.gunaPanel41.SuspendLayout();
			this.gunaPanel39.SuspendLayout();
			this.gunaPanel4.SuspendLayout();
			this.gunaPanel13.SuspendLayout();
			this.gunaPanel44.SuspendLayout();
			this.gunaPanel14.SuspendLayout();
			this.gunaPanel17.SuspendLayout();
			this.gunaPanel19.SuspendLayout();
			this.gunaPanel29.SuspendLayout();
			this.gunaPanel24.SuspendLayout();
			this.gunaPanel27.SuspendLayout();
			this.gunaPanel54.SuspendLayout();
			this.gunaPanel49.SuspendLayout();
			this.gunaPanel34.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gunaPanel84.SuspendLayout();
			this.gunaPanel143.SuspendLayout();
			this.gunaPanel82.SuspendLayout();
			this.gunaPanel72.SuspendLayout();
			this.gunaPanel76.SuspendLayout();
			this.gunaPanel77.SuspendLayout();
			this.gunaPanel94.SuspendLayout();
			this.gunaPanel62.SuspendLayout();
			this.gunaPanel66.SuspendLayout();
			this.gunaPanel67.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.gunaPanel98.SuspendLayout();
			this.gunaPanel112.SuspendLayout();
			this.gunaPanel125.SuspendLayout();
			this.gunaPanel136.SuspendLayout();
			this.gunaPanel126.SuspendLayout();
			this.gunaPanel119.SuspendLayout();
			this.gunaPanel113.SuspendLayout();
			this.gunaPanel96.SuspendLayout();
			this.gunaPanel1.SuspendLayout();
			base.SuspendLayout();
			this.gunaShadowPanel1.BackColor = Color.FromArgb(25, 25, 25);
			this.gunaShadowPanel1.BaseColor = Color.FromArgb(15, 15, 15);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel61);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel60);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel59);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel58);
			this.gunaShadowPanel1.Controls.Add(this.tabControl1);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel5);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel2);
			this.gunaShadowPanel1.Controls.Add(this.gunaPanel1);
			this.gunaShadowPanel1.Dock = DockStyle.Fill;
			this.gunaShadowPanel1.Location = new Point(0, 0);
			this.gunaShadowPanel1.Name = "gunaShadowPanel1";
			this.gunaShadowPanel1.ShadowColor = Color.FromArgb(25, 25, 25);
			this.gunaShadowPanel1.ShadowShift = 7;
			this.gunaShadowPanel1.Size = new Size(807, 567);
			this.gunaShadowPanel1.TabIndex = 0;
			this.gunaShadowPanel1.Paint += this.gunaShadowPanel1_Paint;
			this.gunaPanel61.BackColor = Color.FromArgb(15, 15, 15);
			this.gunaPanel61.Location = new Point(786, 36);
			this.gunaPanel61.Name = "gunaPanel61";
			this.gunaPanel61.Size = new Size(10, 516);
			this.gunaPanel61.TabIndex = 6;
			this.gunaPanel61.Paint += this.gunaPanel58_Paint;
			this.gunaPanel60.BackColor = Color.FromArgb(15, 15, 15);
			this.gunaPanel60.Location = new Point(95, 42);
			this.gunaPanel60.Name = "gunaPanel60";
			this.gunaPanel60.Size = new Size(13, 506);
			this.gunaPanel60.TabIndex = 6;
			this.gunaPanel60.Paint += this.gunaPanel58_Paint;
			this.gunaPanel59.BackColor = Color.FromArgb(15, 15, 15);
			this.gunaPanel59.Location = new Point(95, 547);
			this.gunaPanel59.Name = "gunaPanel59";
			this.gunaPanel59.Size = new Size(700, 10);
			this.gunaPanel59.TabIndex = 6;
			this.gunaPanel59.Paint += this.gunaPanel58_Paint;
			this.gunaPanel58.BackColor = Color.FromArgb(15, 15, 15);
			this.gunaPanel58.Location = new Point(95, 18);
			this.gunaPanel58.Name = "gunaPanel58";
			this.gunaPanel58.Size = new Size(700, 24);
			this.gunaPanel58.TabIndex = 6;
			this.gunaPanel58.Paint += this.gunaPanel58_Paint;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new Point(96, 18);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(699, 534);
			this.tabControl1.TabIndex = 6;
			this.tabPage1.BackColor = Color.FromArgb(15, 15, 15);
			this.tabPage1.Controls.Add(this.gunaPanel142);
			this.tabPage1.Controls.Add(this.gunaPanel3);
			this.tabPage1.Controls.Add(this.gunaPanel4);
			this.tabPage1.Controls.Add(this.gunaPanel14);
			this.tabPage1.Controls.Add(this.gunaPanel29);
			this.tabPage1.Controls.Add(this.gunaPanel24);
			this.tabPage1.Controls.Add(this.gunaPanel34);
			this.tabPage1.Controls.Add(this.gunaAdvenceButton7);
			this.tabPage1.Controls.Add(this.gunaAdvenceButton14);
			this.tabPage1.Controls.Add(this.gunaAdvenceButton8);
			this.tabPage1.Controls.Add(this.gunaAdvenceButton13);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(691, 508);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.gunaPanel142.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel142.Controls.Add(this.gunaPanel144);
			this.gunaPanel142.Controls.Add(this.gunaLabel70);
			this.gunaPanel142.Location = new Point(529, 456);
			this.gunaPanel142.Name = "gunaPanel142";
			this.gunaPanel142.Size = new Size(200, 45);
			this.gunaPanel142.TabIndex = 6;
			this.gunaPanel142.Visible = false;
			this.gunaPanel144.BackColor = Color.FromArgb(10, 10, 10);
			this.gunaPanel144.Location = new Point(1, 0);
			this.gunaPanel144.Name = "gunaPanel144";
			this.gunaPanel144.Size = new Size(5, 45);
			this.gunaPanel144.TabIndex = 6;
			this.gunaLabel70.AutoSize = true;
			this.gunaLabel70.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel70.ForeColor = Color.White;
			this.gunaLabel70.Location = new Point(12, 11);
			this.gunaLabel70.Name = "gunaLabel70";
			this.gunaLabel70.Size = new Size(58, 21);
			this.gunaLabel70.TabIndex = 1;
			this.gunaLabel70.Text = "SAVED";
			this.gunaPanel3.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel3.Controls.Add(this.gunaLabel87);
			this.gunaPanel3.Controls.Add(this.gunaTextBox5);
			this.gunaPanel3.Controls.Add(this.gunaLabel14);
			this.gunaPanel3.Controls.Add(this.gunaLabel15);
			this.gunaPanel3.Controls.Add(this.gunaLabel13);
			this.gunaPanel3.Controls.Add(this.gunaLabel12);
			this.gunaPanel3.Controls.Add(this.gunaAdvenceButton1);
			this.gunaPanel3.Controls.Add(this.gunaShadowPanel5);
			this.gunaPanel3.Controls.Add(this.gunaShadowPanel3);
			this.gunaPanel3.Controls.Add(this.gunaShadowPanel4);
			this.gunaPanel3.Controls.Add(this.gunaPanel43);
			this.gunaPanel3.Controls.Add(this.gunaShadowPanel2);
			this.gunaPanel3.Controls.Add(this.gunaLabel11);
			this.gunaPanel3.Controls.Add(this.gunaLabel10);
			this.gunaPanel3.Controls.Add(this.gunaPanel42);
			this.gunaPanel3.Controls.Add(this.gunaPanel40);
			this.gunaPanel3.Controls.Add(this.gunaPanel41);
			this.gunaPanel3.Controls.Add(this.bunifuSlider2);
			this.gunaPanel3.Controls.Add(this.gunaPanel39);
			this.gunaPanel3.Controls.Add(this.bunifuSlider1);
			this.gunaPanel3.Controls.Add(this.gunaLabel1);
			this.gunaPanel3.Controls.Add(this.gunaPanel9);
			this.gunaPanel3.Controls.Add(this.gunaPanel8);
			this.gunaPanel3.Controls.Add(this.gunaPanel7);
			this.gunaPanel3.Controls.Add(this.gunaPanel6);
			this.gunaPanel3.Location = new Point(22, 2);
			this.gunaPanel3.Name = "gunaPanel3";
			this.gunaPanel3.Size = new Size(248, 258);
			this.gunaPanel3.TabIndex = 0;
			this.gunaPanel3.Paint += this.gunaPanel3_Paint;
			this.gunaLabel87.AutoSize = true;
			this.gunaLabel87.BackColor = Color.FromArgb(8, 8, 8);
			this.gunaLabel87.Font = new Font("Segoe UI", 7f);
			this.gunaLabel87.ForeColor = Color.Silver;
			this.gunaLabel87.Location = new Point(117, 233);
			this.gunaLabel87.Name = "gunaLabel87";
			this.gunaLabel87.Size = new Size(28, 12);
			this.gunaLabel87.TabIndex = 8;
			this.gunaLabel87.Text = "BIND";
			this.gunaTextBox5.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox5.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox5.Cursor = Cursors.IBeam;
			this.gunaTextBox5.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox5.FocusedBorderColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox5.FocusedForeColor = Color.Silver;
			this.gunaTextBox5.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox5.ForeColor = Color.Silver;
			this.gunaTextBox5.Location = new Point(116, 211);
			this.gunaTextBox5.Name = "gunaTextBox5";
			this.gunaTextBox5.PasswordChar = '\0';
			this.gunaTextBox5.SelectedText = "";
			this.gunaTextBox5.Size = new Size(96, 37);
			this.gunaTextBox5.TabIndex = 7;
			this.gunaTextBox5.TextAlign = HorizontalAlignment.Center;
			this.gunaTextBox5.TextChanged += this.gunaTextBox4_TextChanged;
			this.gunaTextBox5.Click += this.gunaTextBox4_Click;
			this.gunaLabel14.AutoSize = true;
			this.gunaLabel14.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel14.ForeColor = Color.Silver;
			this.gunaLabel14.Location = new Point(39, 162);
			this.gunaLabel14.Name = "gunaLabel14";
			this.gunaLabel14.Size = new Size(96, 13);
			this.gunaLabel14.TabIndex = 1;
			this.gunaLabel14.Text = "Disable Inventory";
			this.gunaLabel14.Click += this.gunaLabel14_Click;
			this.gunaLabel15.AutoSize = true;
			this.gunaLabel15.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel15.ForeColor = Color.Silver;
			this.gunaLabel15.Location = new Point(39, 183);
			this.gunaLabel15.Name = "gunaLabel15";
			this.gunaLabel15.Size = new Size(95, 13);
			this.gunaLabel15.TabIndex = 1;
			this.gunaLabel15.Text = "Auto DoubleClick";
			this.gunaLabel15.Click += this.gunaLabel15_Click;
			this.gunaLabel13.AutoSize = true;
			this.gunaLabel13.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel13.ForeColor = Color.Silver;
			this.gunaLabel13.Location = new Point(39, 141);
			this.gunaLabel13.Name = "gunaLabel13";
			this.gunaLabel13.Size = new Size(69, 13);
			this.gunaLabel13.TabIndex = 1;
			this.gunaLabel13.Text = "BreakBlocks";
			this.gunaLabel13.Click += this.gunaLabel13_Click;
			this.gunaLabel12.AutoSize = true;
			this.gunaLabel12.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel12.ForeColor = Color.Silver;
			this.gunaLabel12.Location = new Point(39, 120);
			this.gunaLabel12.Name = "gunaLabel12";
			this.gunaLabel12.Size = new Size(44, 13);
			this.gunaLabel12.TabIndex = 1;
			this.gunaLabel12.Text = "CSprint";
			this.gunaLabel12.Click += this.gunaLabel12_Click;
			this.gunaAdvenceButton1.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton1.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton1.BackColor = Color.Transparent;
			this.gunaAdvenceButton1.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton1.BorderColor = Color.Black;
			this.gunaAdvenceButton1.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton1.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton1.CheckedForeColor = Color.White;
			this.gunaAdvenceButton1.CheckedImage = null;
			this.gunaAdvenceButton1.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton1.DialogResult = DialogResult.None;
			this.gunaAdvenceButton1.FocusedColor = Color.Empty;
			this.gunaAdvenceButton1.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton1.ForeColor = Color.Silver;
			this.gunaAdvenceButton1.Image = null;
			this.gunaAdvenceButton1.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton1.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton1.Location = new Point(14, 211);
			this.gunaAdvenceButton1.Name = "gunaAdvenceButton1";
			this.gunaAdvenceButton1.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton1.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton1.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton1.OnHoverImage = null;
			this.gunaAdvenceButton1.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton1.OnPressedColor = Color.Black;
			this.gunaAdvenceButton1.Radius = 2;
			this.gunaAdvenceButton1.Size = new Size(96, 37);
			this.gunaAdvenceButton1.TabIndex = 5;
			this.gunaAdvenceButton1.Text = "Enable";
			this.gunaAdvenceButton1.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton1.Click += this.gunaAdvenceButton1_Click;
			this.gunaShadowPanel5.BackColor = Color.Transparent;
			this.gunaShadowPanel5.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel5.Location = new Point(12, 178);
			this.gunaShadowPanel5.Name = "gunaShadowPanel5";
			this.gunaShadowPanel5.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel5.ShadowShift = 2;
			this.gunaShadowPanel5.Size = new Size(21, 18);
			this.gunaShadowPanel5.TabIndex = 4;
			this.gunaShadowPanel5.Click += this.gunaShadowPanel5_Click;
			this.gunaShadowPanel3.BackColor = Color.Transparent;
			this.gunaShadowPanel3.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel3.Location = new Point(12, 136);
			this.gunaShadowPanel3.Name = "gunaShadowPanel3";
			this.gunaShadowPanel3.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel3.ShadowShift = 2;
			this.gunaShadowPanel3.Size = new Size(21, 18);
			this.gunaShadowPanel3.TabIndex = 4;
			this.gunaShadowPanel3.Click += this.gunaShadowPanel3_Click;
			this.gunaShadowPanel4.BackColor = Color.Transparent;
			this.gunaShadowPanel4.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel4.Location = new Point(12, 157);
			this.gunaShadowPanel4.Name = "gunaShadowPanel4";
			this.gunaShadowPanel4.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel4.ShadowShift = 2;
			this.gunaShadowPanel4.Size = new Size(21, 18);
			this.gunaShadowPanel4.TabIndex = 4;
			this.gunaShadowPanel4.Click += this.gunaShadowPanel4_Click;
			this.gunaPanel43.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel43.Location = new Point(15, 200);
			this.gunaPanel43.Name = "gunaPanel43";
			this.gunaPanel43.Size = new Size(191, 2);
			this.gunaPanel43.TabIndex = 0;
			this.gunaShadowPanel2.BackColor = Color.Transparent;
			this.gunaShadowPanel2.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel2.Location = new Point(12, 115);
			this.gunaShadowPanel2.Name = "gunaShadowPanel2";
			this.gunaShadowPanel2.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel2.ShadowShift = 2;
			this.gunaShadowPanel2.Size = new Size(21, 18);
			this.gunaShadowPanel2.TabIndex = 4;
			this.gunaShadowPanel2.Click += this.gunaShadowPanel2_Click;
			this.gunaLabel11.AutoSize = true;
			this.gunaLabel11.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel11.ForeColor = Color.Silver;
			this.gunaLabel11.Location = new Point(217, 88);
			this.gunaLabel11.Name = "gunaLabel11";
			this.gunaLabel11.Size = new Size(13, 13);
			this.gunaLabel11.TabIndex = 1;
			this.gunaLabel11.Text = "0";
			this.gunaLabel10.AutoSize = true;
			this.gunaLabel10.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel10.ForeColor = Color.Silver;
			this.gunaLabel10.Location = new Point(217, 43);
			this.gunaLabel10.Name = "gunaLabel10";
			this.gunaLabel10.Size = new Size(13, 13);
			this.gunaLabel10.TabIndex = 1;
			this.gunaLabel10.Text = "0";
			this.gunaPanel42.Location = new Point(11, 99);
			this.gunaPanel42.Name = "gunaPanel42";
			this.gunaPanel42.Size = new Size(200, 15);
			this.gunaPanel42.TabIndex = 3;
			this.gunaPanel40.Location = new Point(11, 56);
			this.gunaPanel40.Name = "gunaPanel40";
			this.gunaPanel40.Size = new Size(200, 15);
			this.gunaPanel40.TabIndex = 3;
			this.gunaPanel41.Controls.Add(this.gunaLabel9);
			this.gunaPanel41.Location = new Point(11, 75);
			this.gunaPanel41.Name = "gunaPanel41";
			this.gunaPanel41.Size = new Size(200, 15);
			this.gunaPanel41.TabIndex = 3;
			this.gunaLabel9.AutoSize = true;
			this.gunaLabel9.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel9.ForeColor = Color.Silver;
			this.gunaLabel9.Location = new Point(-2, 3);
			this.gunaLabel9.Name = "gunaLabel9";
			this.gunaLabel9.Size = new Size(77, 13);
			this.gunaLabel9.TabIndex = 1;
			this.gunaLabel9.Text = "MaximumCps";
			this.bunifuSlider2.BackColor = Color.Transparent;
			this.bunifuSlider2.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider2.BorderRadius = 0;
			this.bunifuSlider2.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider2.Location = new Point(11, 82);
			this.bunifuSlider2.MaximumValue = 25;
			this.bunifuSlider2.Name = "bunifuSlider2";
			this.bunifuSlider2.Size = new Size(200, 30);
			this.bunifuSlider2.TabIndex = 2;
			this.bunifuSlider2.Value = 0;
			this.gunaPanel39.Controls.Add(this.gunaLabel8);
			this.gunaPanel39.Location = new Point(11, 32);
			this.gunaPanel39.Name = "gunaPanel39";
			this.gunaPanel39.Size = new Size(200, 15);
			this.gunaPanel39.TabIndex = 3;
			this.gunaLabel8.AutoSize = true;
			this.gunaLabel8.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel8.ForeColor = Color.Silver;
			this.gunaLabel8.Location = new Point(-2, 3);
			this.gunaLabel8.Name = "gunaLabel8";
			this.gunaLabel8.Size = new Size(74, 13);
			this.gunaLabel8.TabIndex = 1;
			this.gunaLabel8.Text = "MinimumCps";
			this.bunifuSlider1.BackColor = Color.Transparent;
			this.bunifuSlider1.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider1.BorderRadius = 0;
			this.bunifuSlider1.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider1.Location = new Point(11, 39);
			this.bunifuSlider1.MaximumValue = 25;
			this.bunifuSlider1.Name = "bunifuSlider1";
			this.bunifuSlider1.Size = new Size(200, 30);
			this.bunifuSlider1.TabIndex = 2;
			this.bunifuSlider1.Value = 0;
			this.gunaLabel1.AutoSize = true;
			this.gunaLabel1.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel1.ForeColor = Color.Silver;
			this.gunaLabel1.Location = new Point(8, 7);
			this.gunaLabel1.Name = "gunaLabel1";
			this.gunaLabel1.Size = new Size(69, 17);
			this.gunaLabel1.TabIndex = 1;
			this.gunaLabel1.Text = "LeftClicker";
			this.gunaPanel9.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel9.Dock = DockStyle.Left;
			this.gunaPanel9.Location = new Point(0, 2);
			this.gunaPanel9.Name = "gunaPanel9";
			this.gunaPanel9.Size = new Size(2, 254);
			this.gunaPanel9.TabIndex = 0;
			this.gunaPanel8.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel8.Dock = DockStyle.Bottom;
			this.gunaPanel8.Location = new Point(0, 256);
			this.gunaPanel8.Name = "gunaPanel8";
			this.gunaPanel8.Size = new Size(246, 2);
			this.gunaPanel8.TabIndex = 0;
			this.gunaPanel7.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel7.Dock = DockStyle.Top;
			this.gunaPanel7.Location = new Point(0, 0);
			this.gunaPanel7.Name = "gunaPanel7";
			this.gunaPanel7.Size = new Size(246, 2);
			this.gunaPanel7.TabIndex = 0;
			this.gunaPanel6.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel6.Dock = DockStyle.Right;
			this.gunaPanel6.Location = new Point(246, 0);
			this.gunaPanel6.Name = "gunaPanel6";
			this.gunaPanel6.Size = new Size(2, 258);
			this.gunaPanel6.TabIndex = 0;
			this.gunaPanel4.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel4.Controls.Add(this.gunaLabel88);
			this.gunaPanel4.Controls.Add(this.gunaTextBox4);
			this.gunaPanel4.Controls.Add(this.gunaLabel18);
			this.gunaPanel4.Controls.Add(this.gunaAdvenceButton3);
			this.gunaPanel4.Controls.Add(this.gunaAdvenceButton4);
			this.gunaPanel4.Controls.Add(this.gunaShadowPanel9);
			this.gunaPanel4.Controls.Add(this.gunaLabel19);
			this.gunaPanel4.Controls.Add(this.gunaAdvenceButton5);
			this.gunaPanel4.Controls.Add(this.gunaLabel20);
			this.gunaPanel4.Controls.Add(this.gunaPanel11);
			this.gunaPanel4.Controls.Add(this.gunaPanel12);
			this.gunaPanel4.Controls.Add(this.gunaPanel13);
			this.gunaPanel4.Controls.Add(this.gunaPanel10);
			this.gunaPanel4.Controls.Add(this.bunifuSlider3);
			this.gunaPanel4.Controls.Add(this.gunaPanel44);
			this.gunaPanel4.Controls.Add(this.bunifuSlider4);
			this.gunaPanel4.Controls.Add(this.gunaLabel23);
			this.gunaPanel4.Controls.Add(this.gunaPanel45);
			this.gunaPanel4.Controls.Add(this.gunaPanel46);
			this.gunaPanel4.Controls.Add(this.gunaPanel47);
			this.gunaPanel4.Controls.Add(this.gunaPanel48);
			this.gunaPanel4.Location = new Point(276, 2);
			this.gunaPanel4.Name = "gunaPanel4";
			this.gunaPanel4.Size = new Size(248, 203);
			this.gunaPanel4.TabIndex = 0;
			this.gunaPanel4.Paint += this.gunaPanel3_Paint;
			this.gunaLabel88.AutoSize = true;
			this.gunaLabel88.BackColor = Color.FromArgb(8, 8, 8);
			this.gunaLabel88.Font = new Font("Segoe UI", 7f);
			this.gunaLabel88.ForeColor = Color.Silver;
			this.gunaLabel88.Location = new Point(121, 177);
			this.gunaLabel88.Name = "gunaLabel88";
			this.gunaLabel88.Size = new Size(28, 12);
			this.gunaLabel88.TabIndex = 8;
			this.gunaLabel88.Text = "BIND";
			this.gunaTextBox4.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox4.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox4.Cursor = Cursors.IBeam;
			this.gunaTextBox4.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox4.FocusedBorderColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox4.FocusedForeColor = Color.Silver;
			this.gunaTextBox4.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox4.ForeColor = Color.Silver;
			this.gunaTextBox4.Location = new Point(118, 152);
			this.gunaTextBox4.Name = "gunaTextBox4";
			this.gunaTextBox4.PasswordChar = '\0';
			this.gunaTextBox4.SelectedText = "";
			this.gunaTextBox4.Size = new Size(96, 37);
			this.gunaTextBox4.TabIndex = 7;
			this.gunaTextBox4.TextAlign = HorizontalAlignment.Center;
			this.gunaTextBox4.TextChanged += this.gunaTextBox4_TextChanged;
			this.gunaTextBox4.Click += this.gunaTextBox4_Click;
			this.gunaLabel18.AutoSize = true;
			this.gunaLabel18.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel18.ForeColor = Color.Silver;
			this.gunaLabel18.Location = new Point(35, 119);
			this.gunaLabel18.Name = "gunaLabel18";
			this.gunaLabel18.Size = new Size(96, 13);
			this.gunaLabel18.TabIndex = 1;
			this.gunaLabel18.Text = "Disable Inventory";
			this.gunaLabel18.Click += this.gunaLabel18_Click;
			this.gunaAdvenceButton3.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton3.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton3.BackColor = Color.Transparent;
			this.gunaAdvenceButton3.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton3.BorderColor = Color.Black;
			this.gunaAdvenceButton3.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton3.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton3.CheckedForeColor = Color.White;
			this.gunaAdvenceButton3.CheckedImage = null;
			this.gunaAdvenceButton3.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton3.DialogResult = DialogResult.None;
			this.gunaAdvenceButton3.FocusedColor = Color.Empty;
			this.gunaAdvenceButton3.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton3.ForeColor = Color.Silver;
			this.gunaAdvenceButton3.Image = null;
			this.gunaAdvenceButton3.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton3.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton3.Location = new Point(116, 211);
			this.gunaAdvenceButton3.Name = "gunaAdvenceButton3";
			this.gunaAdvenceButton3.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton3.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton3.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton3.OnHoverImage = null;
			this.gunaAdvenceButton3.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton3.OnPressedColor = Color.Black;
			this.gunaAdvenceButton3.Radius = 2;
			this.gunaAdvenceButton3.Size = new Size(96, 37);
			this.gunaAdvenceButton3.TabIndex = 5;
			this.gunaAdvenceButton3.Text = "Bind";
			this.gunaAdvenceButton3.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton4.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton4.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton4.BackColor = Color.Transparent;
			this.gunaAdvenceButton4.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton4.BorderColor = Color.Black;
			this.gunaAdvenceButton4.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton4.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton4.CheckedForeColor = Color.White;
			this.gunaAdvenceButton4.CheckedImage = null;
			this.gunaAdvenceButton4.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton4.DialogResult = DialogResult.None;
			this.gunaAdvenceButton4.FocusedColor = Color.Empty;
			this.gunaAdvenceButton4.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton4.ForeColor = Color.Silver;
			this.gunaAdvenceButton4.Image = null;
			this.gunaAdvenceButton4.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton4.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton4.Location = new Point(14, 211);
			this.gunaAdvenceButton4.Name = "gunaAdvenceButton4";
			this.gunaAdvenceButton4.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton4.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton4.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton4.OnHoverImage = null;
			this.gunaAdvenceButton4.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton4.OnPressedColor = Color.Black;
			this.gunaAdvenceButton4.Radius = 2;
			this.gunaAdvenceButton4.Size = new Size(96, 37);
			this.gunaAdvenceButton4.TabIndex = 5;
			this.gunaAdvenceButton4.Text = "Enable";
			this.gunaAdvenceButton4.TextAlign = HorizontalAlignment.Center;
			this.gunaShadowPanel9.BackColor = Color.Transparent;
			this.gunaShadowPanel9.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel9.Location = new Point(12, 115);
			this.gunaShadowPanel9.Name = "gunaShadowPanel9";
			this.gunaShadowPanel9.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel9.ShadowShift = 2;
			this.gunaShadowPanel9.Size = new Size(21, 18);
			this.gunaShadowPanel9.TabIndex = 4;
			this.gunaShadowPanel9.Click += this.gunaShadowPanel9_Click;
			this.gunaLabel19.AutoSize = true;
			this.gunaLabel19.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel19.ForeColor = Color.Silver;
			this.gunaLabel19.Location = new Point(218, 88);
			this.gunaLabel19.Name = "gunaLabel19";
			this.gunaLabel19.Size = new Size(13, 13);
			this.gunaLabel19.TabIndex = 1;
			this.gunaLabel19.Text = "0";
			this.gunaAdvenceButton5.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton5.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton5.BackColor = Color.Transparent;
			this.gunaAdvenceButton5.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton5.BorderColor = Color.Black;
			this.gunaAdvenceButton5.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton5.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton5.CheckedForeColor = Color.White;
			this.gunaAdvenceButton5.CheckedImage = null;
			this.gunaAdvenceButton5.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton5.DialogResult = DialogResult.None;
			this.gunaAdvenceButton5.FocusedColor = Color.Empty;
			this.gunaAdvenceButton5.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton5.ForeColor = Color.Silver;
			this.gunaAdvenceButton5.Image = null;
			this.gunaAdvenceButton5.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton5.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton5.Location = new Point(19, 152);
			this.gunaAdvenceButton5.Name = "gunaAdvenceButton5";
			this.gunaAdvenceButton5.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton5.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton5.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton5.OnHoverImage = null;
			this.gunaAdvenceButton5.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton5.OnPressedColor = Color.Black;
			this.gunaAdvenceButton5.Radius = 2;
			this.gunaAdvenceButton5.Size = new Size(96, 37);
			this.gunaAdvenceButton5.TabIndex = 5;
			this.gunaAdvenceButton5.Text = "Enable";
			this.gunaAdvenceButton5.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton5.Click += this.gunaAdvenceButton5_Click;
			this.gunaLabel20.AutoSize = true;
			this.gunaLabel20.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel20.ForeColor = Color.Silver;
			this.gunaLabel20.Location = new Point(218, 43);
			this.gunaLabel20.Name = "gunaLabel20";
			this.gunaLabel20.Size = new Size(13, 13);
			this.gunaLabel20.TabIndex = 1;
			this.gunaLabel20.Text = "0";
			this.gunaPanel11.Location = new Point(11, 99);
			this.gunaPanel11.Name = "gunaPanel11";
			this.gunaPanel11.Size = new Size(200, 15);
			this.gunaPanel11.TabIndex = 3;
			this.gunaPanel12.Location = new Point(11, 56);
			this.gunaPanel12.Name = "gunaPanel12";
			this.gunaPanel12.Size = new Size(200, 15);
			this.gunaPanel12.TabIndex = 3;
			this.gunaPanel13.Controls.Add(this.gunaLabel21);
			this.gunaPanel13.Location = new Point(11, 75);
			this.gunaPanel13.Name = "gunaPanel13";
			this.gunaPanel13.Size = new Size(200, 15);
			this.gunaPanel13.TabIndex = 3;
			this.gunaLabel21.AutoSize = true;
			this.gunaLabel21.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel21.ForeColor = Color.Silver;
			this.gunaLabel21.Location = new Point(-2, 3);
			this.gunaLabel21.Name = "gunaLabel21";
			this.gunaLabel21.Size = new Size(77, 13);
			this.gunaLabel21.TabIndex = 1;
			this.gunaLabel21.Text = "MaximumCps";
			this.gunaPanel10.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel10.Location = new Point(20, 141);
			this.gunaPanel10.Name = "gunaPanel10";
			this.gunaPanel10.Size = new Size(191, 2);
			this.gunaPanel10.TabIndex = 0;
			this.bunifuSlider3.BackColor = Color.Transparent;
			this.bunifuSlider3.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider3.BorderRadius = 0;
			this.bunifuSlider3.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider3.Location = new Point(11, 82);
			this.bunifuSlider3.MaximumValue = 25;
			this.bunifuSlider3.Name = "bunifuSlider3";
			this.bunifuSlider3.Size = new Size(200, 30);
			this.bunifuSlider3.TabIndex = 2;
			this.bunifuSlider3.Value = 0;
			this.gunaPanel44.Controls.Add(this.gunaLabel22);
			this.gunaPanel44.Location = new Point(11, 32);
			this.gunaPanel44.Name = "gunaPanel44";
			this.gunaPanel44.Size = new Size(200, 15);
			this.gunaPanel44.TabIndex = 3;
			this.gunaLabel22.AutoSize = true;
			this.gunaLabel22.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel22.ForeColor = Color.Silver;
			this.gunaLabel22.Location = new Point(-2, 3);
			this.gunaLabel22.Name = "gunaLabel22";
			this.gunaLabel22.Size = new Size(74, 13);
			this.gunaLabel22.TabIndex = 1;
			this.gunaLabel22.Text = "MinimumCps";
			this.bunifuSlider4.BackColor = Color.Transparent;
			this.bunifuSlider4.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider4.BorderRadius = 0;
			this.bunifuSlider4.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider4.Location = new Point(11, 39);
			this.bunifuSlider4.MaximumValue = 25;
			this.bunifuSlider4.Name = "bunifuSlider4";
			this.bunifuSlider4.Size = new Size(200, 30);
			this.bunifuSlider4.TabIndex = 2;
			this.bunifuSlider4.Value = 0;
			this.gunaLabel23.AutoSize = true;
			this.gunaLabel23.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel23.ForeColor = Color.Silver;
			this.gunaLabel23.Location = new Point(8, 10);
			this.gunaLabel23.Name = "gunaLabel23";
			this.gunaLabel23.Size = new Size(79, 17);
			this.gunaLabel23.TabIndex = 1;
			this.gunaLabel23.Text = "RightClicker";
			this.gunaLabel23.Click += this.gunaLabel23_Click;
			this.gunaPanel45.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel45.Dock = DockStyle.Left;
			this.gunaPanel45.Location = new Point(0, 2);
			this.gunaPanel45.Name = "gunaPanel45";
			this.gunaPanel45.Size = new Size(2, 199);
			this.gunaPanel45.TabIndex = 0;
			this.gunaPanel46.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel46.Dock = DockStyle.Bottom;
			this.gunaPanel46.Location = new Point(0, 201);
			this.gunaPanel46.Name = "gunaPanel46";
			this.gunaPanel46.Size = new Size(246, 2);
			this.gunaPanel46.TabIndex = 0;
			this.gunaPanel47.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel47.Dock = DockStyle.Top;
			this.gunaPanel47.Location = new Point(0, 0);
			this.gunaPanel47.Name = "gunaPanel47";
			this.gunaPanel47.Size = new Size(246, 2);
			this.gunaPanel47.TabIndex = 0;
			this.gunaPanel48.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel48.Dock = DockStyle.Right;
			this.gunaPanel48.Location = new Point(246, 0);
			this.gunaPanel48.Name = "gunaPanel48";
			this.gunaPanel48.Size = new Size(2, 203);
			this.gunaPanel48.TabIndex = 0;
			this.gunaPanel14.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel14.Controls.Add(this.gunaLabel89);
			this.gunaPanel14.Controls.Add(this.gunaTextBox6);
			this.gunaPanel14.Controls.Add(this.gunaAdvenceButton9);
			this.gunaPanel14.Controls.Add(this.gunaAdvenceButton10);
			this.gunaPanel14.Controls.Add(this.gunaLabel3);
			this.gunaPanel14.Controls.Add(this.gunaAdvenceButton12);
			this.gunaPanel14.Controls.Add(this.gunaLabel4);
			this.gunaPanel14.Controls.Add(this.gunaPanel15);
			this.gunaPanel14.Controls.Add(this.gunaPanel16);
			this.gunaPanel14.Controls.Add(this.gunaPanel17);
			this.gunaPanel14.Controls.Add(this.gunaPanel18);
			this.gunaPanel14.Controls.Add(this.bunifuSlider5);
			this.gunaPanel14.Controls.Add(this.gunaPanel19);
			this.gunaPanel14.Controls.Add(this.bunifuSlider6);
			this.gunaPanel14.Controls.Add(this.gunaLabel24);
			this.gunaPanel14.Controls.Add(this.gunaPanel20);
			this.gunaPanel14.Controls.Add(this.gunaPanel21);
			this.gunaPanel14.Controls.Add(this.gunaPanel22);
			this.gunaPanel14.Controls.Add(this.gunaPanel23);
			this.gunaPanel14.Location = new Point(22, 264);
			this.gunaPanel14.Name = "gunaPanel14";
			this.gunaPanel14.Size = new Size(248, 183);
			this.gunaPanel14.TabIndex = 0;
			this.gunaPanel14.Paint += this.gunaPanel3_Paint;
			this.gunaLabel89.AutoSize = true;
			this.gunaLabel89.BackColor = Color.FromArgb(8, 8, 8);
			this.gunaLabel89.Font = new Font("Segoe UI", 7f);
			this.gunaLabel89.ForeColor = Color.Silver;
			this.gunaLabel89.Location = new Point(122, 162);
			this.gunaLabel89.Name = "gunaLabel89";
			this.gunaLabel89.Size = new Size(28, 12);
			this.gunaLabel89.TabIndex = 8;
			this.gunaLabel89.Text = "BIND";
			this.gunaTextBox6.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox6.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox6.Cursor = Cursors.IBeam;
			this.gunaTextBox6.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox6.FocusedBorderColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox6.FocusedForeColor = Color.Silver;
			this.gunaTextBox6.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox6.ForeColor = Color.Silver;
			this.gunaTextBox6.Location = new Point(121, 137);
			this.gunaTextBox6.Name = "gunaTextBox6";
			this.gunaTextBox6.PasswordChar = '\0';
			this.gunaTextBox6.SelectedText = "";
			this.gunaTextBox6.Size = new Size(96, 37);
			this.gunaTextBox6.TabIndex = 7;
			this.gunaTextBox6.TextAlign = HorizontalAlignment.Center;
			this.gunaTextBox6.TextChanged += this.gunaTextBox4_TextChanged;
			this.gunaTextBox6.Click += this.gunaTextBox4_Click;
			this.gunaAdvenceButton9.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton9.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton9.BackColor = Color.Transparent;
			this.gunaAdvenceButton9.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton9.BorderColor = Color.Black;
			this.gunaAdvenceButton9.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton9.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton9.CheckedForeColor = Color.White;
			this.gunaAdvenceButton9.CheckedImage = null;
			this.gunaAdvenceButton9.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton9.DialogResult = DialogResult.None;
			this.gunaAdvenceButton9.FocusedColor = Color.Empty;
			this.gunaAdvenceButton9.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton9.ForeColor = Color.Silver;
			this.gunaAdvenceButton9.Image = null;
			this.gunaAdvenceButton9.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton9.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton9.Location = new Point(116, 211);
			this.gunaAdvenceButton9.Name = "gunaAdvenceButton9";
			this.gunaAdvenceButton9.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton9.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton9.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton9.OnHoverImage = null;
			this.gunaAdvenceButton9.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton9.OnPressedColor = Color.Black;
			this.gunaAdvenceButton9.Radius = 2;
			this.gunaAdvenceButton9.Size = new Size(96, 37);
			this.gunaAdvenceButton9.TabIndex = 5;
			this.gunaAdvenceButton9.Text = "Bind";
			this.gunaAdvenceButton9.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton10.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton10.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton10.BackColor = Color.Transparent;
			this.gunaAdvenceButton10.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton10.BorderColor = Color.Black;
			this.gunaAdvenceButton10.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton10.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton10.CheckedForeColor = Color.White;
			this.gunaAdvenceButton10.CheckedImage = null;
			this.gunaAdvenceButton10.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton10.DialogResult = DialogResult.None;
			this.gunaAdvenceButton10.FocusedColor = Color.Empty;
			this.gunaAdvenceButton10.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton10.ForeColor = Color.Silver;
			this.gunaAdvenceButton10.Image = null;
			this.gunaAdvenceButton10.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton10.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton10.Location = new Point(14, 211);
			this.gunaAdvenceButton10.Name = "gunaAdvenceButton10";
			this.gunaAdvenceButton10.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton10.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton10.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton10.OnHoverImage = null;
			this.gunaAdvenceButton10.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton10.OnPressedColor = Color.Black;
			this.gunaAdvenceButton10.Radius = 2;
			this.gunaAdvenceButton10.Size = new Size(96, 37);
			this.gunaAdvenceButton10.TabIndex = 5;
			this.gunaAdvenceButton10.Text = "Enable";
			this.gunaAdvenceButton10.TextAlign = HorizontalAlignment.Center;
			this.gunaLabel3.AutoSize = true;
			this.gunaLabel3.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel3.ForeColor = Color.Silver;
			this.gunaLabel3.Location = new Point(214, 89);
			this.gunaLabel3.Name = "gunaLabel3";
			this.gunaLabel3.Size = new Size(13, 13);
			this.gunaLabel3.TabIndex = 1;
			this.gunaLabel3.Text = "0";
			this.gunaAdvenceButton12.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton12.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton12.BackColor = Color.Transparent;
			this.gunaAdvenceButton12.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton12.BorderColor = Color.Black;
			this.gunaAdvenceButton12.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton12.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton12.CheckedForeColor = Color.White;
			this.gunaAdvenceButton12.CheckedImage = null;
			this.gunaAdvenceButton12.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton12.DialogResult = DialogResult.None;
			this.gunaAdvenceButton12.FocusedColor = Color.Empty;
			this.gunaAdvenceButton12.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton12.ForeColor = Color.Silver;
			this.gunaAdvenceButton12.Image = null;
			this.gunaAdvenceButton12.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton12.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton12.Location = new Point(19, 137);
			this.gunaAdvenceButton12.Name = "gunaAdvenceButton12";
			this.gunaAdvenceButton12.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton12.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton12.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton12.OnHoverImage = null;
			this.gunaAdvenceButton12.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton12.OnPressedColor = Color.Black;
			this.gunaAdvenceButton12.Radius = 2;
			this.gunaAdvenceButton12.Size = new Size(96, 37);
			this.gunaAdvenceButton12.TabIndex = 5;
			this.gunaAdvenceButton12.Text = "Enable";
			this.gunaAdvenceButton12.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton12.Click += this.gunaAdvenceButton12_Click;
			this.gunaLabel4.AutoSize = true;
			this.gunaLabel4.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel4.ForeColor = Color.Silver;
			this.gunaLabel4.Location = new Point(217, 44);
			this.gunaLabel4.Name = "gunaLabel4";
			this.gunaLabel4.Size = new Size(13, 13);
			this.gunaLabel4.TabIndex = 1;
			this.gunaLabel4.Text = "0";
			this.gunaPanel15.Location = new Point(11, 99);
			this.gunaPanel15.Name = "gunaPanel15";
			this.gunaPanel15.Size = new Size(200, 15);
			this.gunaPanel15.TabIndex = 3;
			this.gunaPanel16.Location = new Point(11, 56);
			this.gunaPanel16.Name = "gunaPanel16";
			this.gunaPanel16.Size = new Size(200, 15);
			this.gunaPanel16.TabIndex = 3;
			this.gunaPanel17.Controls.Add(this.gunaLabel16);
			this.gunaPanel17.Location = new Point(11, 75);
			this.gunaPanel17.Name = "gunaPanel17";
			this.gunaPanel17.Size = new Size(200, 15);
			this.gunaPanel17.TabIndex = 3;
			this.gunaLabel16.AutoSize = true;
			this.gunaLabel16.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel16.ForeColor = Color.Silver;
			this.gunaLabel16.Location = new Point(-2, 3);
			this.gunaLabel16.Name = "gunaLabel16";
			this.gunaLabel16.Size = new Size(43, 13);
			this.gunaLabel16.TabIndex = 1;
			this.gunaLabel16.Text = "Chance";
			this.gunaPanel18.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel18.Location = new Point(20, 126);
			this.gunaPanel18.Name = "gunaPanel18";
			this.gunaPanel18.Size = new Size(191, 2);
			this.gunaPanel18.TabIndex = 0;
			this.bunifuSlider5.BackColor = Color.Transparent;
			this.bunifuSlider5.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider5.BorderRadius = 0;
			this.bunifuSlider5.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider5.Location = new Point(11, 82);
			this.bunifuSlider5.MaximumValue = 100;
			this.bunifuSlider5.Name = "bunifuSlider5";
			this.bunifuSlider5.Size = new Size(200, 30);
			this.bunifuSlider5.TabIndex = 2;
			this.bunifuSlider5.Value = 0;
			this.gunaPanel19.Controls.Add(this.gunaLabel17);
			this.gunaPanel19.Location = new Point(11, 32);
			this.gunaPanel19.Name = "gunaPanel19";
			this.gunaPanel19.Size = new Size(200, 15);
			this.gunaPanel19.TabIndex = 3;
			this.gunaLabel17.AutoSize = true;
			this.gunaLabel17.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel17.ForeColor = Color.Silver;
			this.gunaLabel17.Location = new Point(-2, 3);
			this.gunaLabel17.Name = "gunaLabel17";
			this.gunaLabel17.Size = new Size(57, 13);
			this.gunaLabel17.TabIndex = 1;
			this.gunaLabel17.Text = "Ammount";
			this.bunifuSlider6.BackColor = Color.Transparent;
			this.bunifuSlider6.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider6.BorderRadius = 0;
			this.bunifuSlider6.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider6.Location = new Point(11, 39);
			this.bunifuSlider6.MaximumValue = 30;
			this.bunifuSlider6.Name = "bunifuSlider6";
			this.bunifuSlider6.Size = new Size(200, 30);
			this.bunifuSlider6.TabIndex = 2;
			this.bunifuSlider6.Value = 0;
			this.gunaLabel24.AutoSize = true;
			this.gunaLabel24.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel24.ForeColor = Color.Silver;
			this.gunaLabel24.Location = new Point(8, 7);
			this.gunaLabel24.Name = "gunaLabel24";
			this.gunaLabel24.Size = new Size(44, 17);
			this.gunaLabel24.TabIndex = 1;
			this.gunaLabel24.Text = "Reach";
			this.gunaPanel20.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel20.Dock = DockStyle.Left;
			this.gunaPanel20.Location = new Point(0, 2);
			this.gunaPanel20.Name = "gunaPanel20";
			this.gunaPanel20.Size = new Size(2, 179);
			this.gunaPanel20.TabIndex = 0;
			this.gunaPanel21.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel21.Dock = DockStyle.Bottom;
			this.gunaPanel21.Location = new Point(0, 181);
			this.gunaPanel21.Name = "gunaPanel21";
			this.gunaPanel21.Size = new Size(246, 2);
			this.gunaPanel21.TabIndex = 0;
			this.gunaPanel22.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel22.Dock = DockStyle.Top;
			this.gunaPanel22.Location = new Point(0, 0);
			this.gunaPanel22.Name = "gunaPanel22";
			this.gunaPanel22.Size = new Size(246, 2);
			this.gunaPanel22.TabIndex = 0;
			this.gunaPanel23.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel23.Dock = DockStyle.Right;
			this.gunaPanel23.Location = new Point(246, 0);
			this.gunaPanel23.Name = "gunaPanel23";
			this.gunaPanel23.Size = new Size(2, 183);
			this.gunaPanel23.TabIndex = 0;
			this.gunaPanel29.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel29.Controls.Add(this.bunifuDropdown2);
			this.gunaPanel29.Controls.Add(this.gunaNumeric3);
			this.gunaPanel29.Controls.Add(this.gunaAdvenceButton18);
			this.gunaPanel29.Controls.Add(this.gunaNumeric2);
			this.gunaPanel29.Controls.Add(this.gunaNumeric1);
			this.gunaPanel29.Controls.Add(this.gunaLabel32);
			this.gunaPanel29.Controls.Add(this.gunaLabel31);
			this.gunaPanel29.Controls.Add(this.gunaLabel6);
			this.gunaPanel29.Controls.Add(this.gunaPanel30);
			this.gunaPanel29.Controls.Add(this.gunaPanel31);
			this.gunaPanel29.Controls.Add(this.gunaPanel57);
			this.gunaPanel29.Controls.Add(this.gunaPanel32);
			this.gunaPanel29.Controls.Add(this.gunaPanel33);
			this.gunaPanel29.Location = new Point(533, 211);
			this.gunaPanel29.Name = "gunaPanel29";
			this.gunaPanel29.Size = new Size(140, 234);
			this.gunaPanel29.TabIndex = 0;
			this.bunifuDropdown2.BackColor = Color.Transparent;
			this.bunifuDropdown2.BorderRadius = 3;
			this.bunifuDropdown2.ForeColor = Color.Silver;
			this.bunifuDropdown2.Items = new string[]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			this.bunifuDropdown2.Location = new Point(12, 160);
			this.bunifuDropdown2.Name = "bunifuDropdown2";
			this.bunifuDropdown2.NomalColor = Color.FromArgb(8, 8, 8);
			this.bunifuDropdown2.onHoverColor = Color.FromArgb(10, 10, 10);
			this.bunifuDropdown2.selectedIndex = -1;
			this.bunifuDropdown2.Size = new Size(121, 21);
			this.bunifuDropdown2.TabIndex = 2;
			this.gunaNumeric3.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaNumeric3.BorderColor = Color.FromArgb(12, 12, 12);
			this.gunaNumeric3.ButtonColor = Color.FromArgb(80, 2, 100);
			this.gunaNumeric3.ButtonForeColor = Color.White;
			this.gunaNumeric3.Font = new Font("Segoe UI", 10f);
			this.gunaNumeric3.ForeColor = Color.White;
			this.gunaNumeric3.Location = new Point(11, 111);
			this.gunaNumeric3.Maximum = 9L;
			this.gunaNumeric3.Minimum = 0L;
			this.gunaNumeric3.Name = "gunaNumeric3";
			this.gunaNumeric3.Size = new Size(81, 30);
			this.gunaNumeric3.TabIndex = 2;
			this.gunaNumeric3.Text = "gunaNumeric1";
			this.gunaNumeric3.Value = 0L;
			this.gunaAdvenceButton18.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton18.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton18.BackColor = Color.Transparent;
			this.gunaAdvenceButton18.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton18.BorderColor = Color.Black;
			this.gunaAdvenceButton18.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton18.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton18.CheckedForeColor = Color.White;
			this.gunaAdvenceButton18.CheckedImage = null;
			this.gunaAdvenceButton18.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton18.DialogResult = DialogResult.None;
			this.gunaAdvenceButton18.FocusedColor = Color.Empty;
			this.gunaAdvenceButton18.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton18.ForeColor = Color.Silver;
			this.gunaAdvenceButton18.Image = null;
			this.gunaAdvenceButton18.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton18.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton18.Location = new Point(25, 190);
			this.gunaAdvenceButton18.Name = "gunaAdvenceButton18";
			this.gunaAdvenceButton18.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton18.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton18.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton18.OnHoverImage = null;
			this.gunaAdvenceButton18.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton18.OnPressedColor = Color.Black;
			this.gunaAdvenceButton18.Radius = 2;
			this.gunaAdvenceButton18.Size = new Size(96, 37);
			this.gunaAdvenceButton18.TabIndex = 5;
			this.gunaAdvenceButton18.Text = "Enable";
			this.gunaAdvenceButton18.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton18.Click += this.gunaAdvenceButton18_Click;
			this.gunaNumeric2.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaNumeric2.BorderColor = Color.FromArgb(12, 12, 12);
			this.gunaNumeric2.ButtonColor = Color.FromArgb(80, 2, 100);
			this.gunaNumeric2.ButtonForeColor = Color.White;
			this.gunaNumeric2.Font = new Font("Segoe UI", 10f);
			this.gunaNumeric2.ForeColor = Color.White;
			this.gunaNumeric2.Location = new Point(11, 80);
			this.gunaNumeric2.Maximum = 9L;
			this.gunaNumeric2.Minimum = 0L;
			this.gunaNumeric2.Name = "gunaNumeric2";
			this.gunaNumeric2.Size = new Size(81, 30);
			this.gunaNumeric2.TabIndex = 2;
			this.gunaNumeric2.Text = "gunaNumeric1";
			this.gunaNumeric2.Value = 0L;
			this.gunaNumeric1.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaNumeric1.BorderColor = Color.FromArgb(12, 12, 12);
			this.gunaNumeric1.ButtonColor = Color.FromArgb(80, 2, 100);
			this.gunaNumeric1.ButtonForeColor = Color.White;
			this.gunaNumeric1.Font = new Font("Segoe UI", 10f);
			this.gunaNumeric1.ForeColor = Color.White;
			this.gunaNumeric1.Location = new Point(11, 49);
			this.gunaNumeric1.Maximum = 9L;
			this.gunaNumeric1.Minimum = 0L;
			this.gunaNumeric1.Name = "gunaNumeric1";
			this.gunaNumeric1.Size = new Size(81, 30);
			this.gunaNumeric1.TabIndex = 2;
			this.gunaNumeric1.Text = "gunaNumeric1";
			this.gunaNumeric1.Value = 0L;
			this.gunaLabel32.AutoSize = true;
			this.gunaLabel32.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel32.ForeColor = Color.Silver;
			this.gunaLabel32.Location = new Point(11, 146);
			this.gunaLabel32.Name = "gunaLabel32";
			this.gunaLabel32.Size = new Size(36, 13);
			this.gunaLabel32.TabIndex = 1;
			this.gunaLabel32.Text = "Delay";
			this.gunaLabel31.AutoSize = true;
			this.gunaLabel31.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel31.ForeColor = Color.Silver;
			this.gunaLabel31.Location = new Point(11, 32);
			this.gunaLabel31.Name = "gunaLabel31";
			this.gunaLabel31.Size = new Size(27, 13);
			this.gunaLabel31.TabIndex = 1;
			this.gunaLabel31.Text = "Slot";
			this.gunaLabel6.AutoSize = true;
			this.gunaLabel6.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel6.ForeColor = Color.Silver;
			this.gunaLabel6.Location = new Point(8, 7);
			this.gunaLabel6.Name = "gunaLabel6";
			this.gunaLabel6.Size = new Size(67, 17);
			this.gunaLabel6.TabIndex = 1;
			this.gunaLabel6.Text = "ThrowPot";
			this.gunaPanel30.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel30.Dock = DockStyle.Left;
			this.gunaPanel30.Location = new Point(0, 2);
			this.gunaPanel30.Name = "gunaPanel30";
			this.gunaPanel30.Size = new Size(2, 230);
			this.gunaPanel30.TabIndex = 0;
			this.gunaPanel31.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel31.Dock = DockStyle.Bottom;
			this.gunaPanel31.Location = new Point(0, 232);
			this.gunaPanel31.Name = "gunaPanel31";
			this.gunaPanel31.Size = new Size(138, 2);
			this.gunaPanel31.TabIndex = 0;
			this.gunaPanel57.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel57.Location = new Point(14, 184);
			this.gunaPanel57.Name = "gunaPanel57";
			this.gunaPanel57.Size = new Size(116, 2);
			this.gunaPanel57.TabIndex = 0;
			this.gunaPanel32.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel32.Dock = DockStyle.Top;
			this.gunaPanel32.Location = new Point(0, 0);
			this.gunaPanel32.Name = "gunaPanel32";
			this.gunaPanel32.Size = new Size(138, 2);
			this.gunaPanel32.TabIndex = 0;
			this.gunaPanel33.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel33.Dock = DockStyle.Right;
			this.gunaPanel33.Location = new Point(138, 0);
			this.gunaPanel33.Name = "gunaPanel33";
			this.gunaPanel33.Size = new Size(2, 234);
			this.gunaPanel33.TabIndex = 0;
			this.gunaPanel24.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel24.Controls.Add(this.gunaLabel90);
			this.gunaPanel24.Controls.Add(this.gunaTextBox7);
			this.gunaPanel24.Controls.Add(this.gunaLabel2);
			this.gunaPanel24.Controls.Add(this.gunaAdvenceButton16);
			this.gunaPanel24.Controls.Add(this.gunaLabel30);
			this.gunaPanel24.Controls.Add(this.gunaLabel29);
			this.gunaPanel24.Controls.Add(this.gunaLabel5);
			this.gunaPanel24.Controls.Add(this.gunaPanel25);
			this.gunaPanel24.Controls.Add(this.gunaPanel55);
			this.gunaPanel24.Controls.Add(this.gunaPanel26);
			this.gunaPanel24.Controls.Add(this.gunaPanel27);
			this.gunaPanel24.Controls.Add(this.gunaPanel28);
			this.gunaPanel24.Controls.Add(this.gunaShadowPanel6);
			this.gunaPanel24.Controls.Add(this.bunifuSlider7);
			this.gunaPanel24.Controls.Add(this.gunaPanel54);
			this.gunaPanel24.Controls.Add(this.bunifuSlider9);
			this.gunaPanel24.Controls.Add(this.gunaPanel49);
			this.gunaPanel24.Controls.Add(this.bunifuSlider8);
			this.gunaPanel24.Controls.Add(this.gunaLabel27);
			this.gunaPanel24.Controls.Add(this.gunaPanel50);
			this.gunaPanel24.Controls.Add(this.gunaPanel51);
			this.gunaPanel24.Controls.Add(this.gunaPanel52);
			this.gunaPanel24.Controls.Add(this.gunaPanel53);
			this.gunaPanel24.Location = new Point(276, 213);
			this.gunaPanel24.Name = "gunaPanel24";
			this.gunaPanel24.Size = new Size(248, 234);
			this.gunaPanel24.TabIndex = 0;
			this.gunaPanel24.Paint += this.gunaPanel3_Paint;
			this.gunaLabel90.AutoSize = true;
			this.gunaLabel90.BackColor = Color.FromArgb(8, 8, 8);
			this.gunaLabel90.Font = new Font("Segoe UI", 7f);
			this.gunaLabel90.ForeColor = Color.Silver;
			this.gunaLabel90.Location = new Point(121, 213);
			this.gunaLabel90.Name = "gunaLabel90";
			this.gunaLabel90.Size = new Size(28, 12);
			this.gunaLabel90.TabIndex = 8;
			this.gunaLabel90.Text = "BIND";
			this.gunaTextBox7.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox7.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox7.Cursor = Cursors.IBeam;
			this.gunaTextBox7.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox7.FocusedBorderColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox7.FocusedForeColor = Color.Silver;
			this.gunaTextBox7.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox7.ForeColor = Color.Silver;
			this.gunaTextBox7.Location = new Point(120, 188);
			this.gunaTextBox7.Name = "gunaTextBox7";
			this.gunaTextBox7.PasswordChar = '\0';
			this.gunaTextBox7.SelectedText = "";
			this.gunaTextBox7.Size = new Size(96, 37);
			this.gunaTextBox7.TabIndex = 7;
			this.gunaTextBox7.TextAlign = HorizontalAlignment.Center;
			this.gunaTextBox7.TextChanged += this.gunaTextBox4_TextChanged;
			this.gunaTextBox7.Click += this.gunaTextBox4_Click;
			this.gunaLabel2.AutoSize = true;
			this.gunaLabel2.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel2.ForeColor = Color.Silver;
			this.gunaLabel2.Location = new Point(213, 127);
			this.gunaLabel2.Name = "gunaLabel2";
			this.gunaLabel2.Size = new Size(13, 13);
			this.gunaLabel2.TabIndex = 1;
			this.gunaLabel2.Text = "0";
			this.gunaAdvenceButton16.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton16.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton16.BackColor = Color.Transparent;
			this.gunaAdvenceButton16.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton16.BorderColor = Color.Black;
			this.gunaAdvenceButton16.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton16.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton16.CheckedForeColor = Color.White;
			this.gunaAdvenceButton16.CheckedImage = null;
			this.gunaAdvenceButton16.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton16.DialogResult = DialogResult.None;
			this.gunaAdvenceButton16.FocusedColor = Color.Empty;
			this.gunaAdvenceButton16.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton16.ForeColor = Color.Silver;
			this.gunaAdvenceButton16.Image = null;
			this.gunaAdvenceButton16.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton16.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton16.Location = new Point(18, 188);
			this.gunaAdvenceButton16.Name = "gunaAdvenceButton16";
			this.gunaAdvenceButton16.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton16.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton16.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton16.OnHoverImage = null;
			this.gunaAdvenceButton16.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton16.OnPressedColor = Color.Black;
			this.gunaAdvenceButton16.Radius = 2;
			this.gunaAdvenceButton16.Size = new Size(96, 37);
			this.gunaAdvenceButton16.TabIndex = 5;
			this.gunaAdvenceButton16.Text = "Enable";
			this.gunaAdvenceButton16.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton16.Click += this.gunaAdvenceButton16_Click;
			this.gunaLabel30.AutoSize = true;
			this.gunaLabel30.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel30.ForeColor = Color.Silver;
			this.gunaLabel30.Location = new Point(40, 160);
			this.gunaLabel30.Name = "gunaLabel30";
			this.gunaLabel30.Size = new Size(89, 13);
			this.gunaLabel30.TabIndex = 1;
			this.gunaLabel30.Text = "Require Clicking";
			this.gunaLabel30.Click += this.gunaLabel30_Click;
			this.gunaLabel29.AutoSize = true;
			this.gunaLabel29.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel29.ForeColor = Color.Silver;
			this.gunaLabel29.Location = new Point(213, 86);
			this.gunaLabel29.Name = "gunaLabel29";
			this.gunaLabel29.Size = new Size(13, 13);
			this.gunaLabel29.TabIndex = 1;
			this.gunaLabel29.Text = "0";
			this.gunaLabel5.AutoSize = true;
			this.gunaLabel5.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel5.ForeColor = Color.Silver;
			this.gunaLabel5.Location = new Point(213, 42);
			this.gunaLabel5.Name = "gunaLabel5";
			this.gunaLabel5.Size = new Size(13, 13);
			this.gunaLabel5.TabIndex = 1;
			this.gunaLabel5.Text = "0";
			this.gunaPanel25.Location = new Point(12, 137);
			this.gunaPanel25.Name = "gunaPanel25";
			this.gunaPanel25.Size = new Size(200, 15);
			this.gunaPanel25.TabIndex = 3;
			this.gunaPanel55.Location = new Point(11, 95);
			this.gunaPanel55.Name = "gunaPanel55";
			this.gunaPanel55.Size = new Size(200, 15);
			this.gunaPanel55.TabIndex = 3;
			this.gunaPanel26.Location = new Point(11, 56);
			this.gunaPanel26.Name = "gunaPanel26";
			this.gunaPanel26.Size = new Size(200, 15);
			this.gunaPanel26.TabIndex = 3;
			this.gunaPanel27.Controls.Add(this.gunaLabel25);
			this.gunaPanel27.Location = new Point(12, 113);
			this.gunaPanel27.Name = "gunaPanel27";
			this.gunaPanel27.Size = new Size(200, 15);
			this.gunaPanel27.TabIndex = 3;
			this.gunaLabel25.AutoSize = true;
			this.gunaLabel25.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel25.ForeColor = Color.Silver;
			this.gunaLabel25.Location = new Point(-2, 3);
			this.gunaLabel25.Name = "gunaLabel25";
			this.gunaLabel25.Size = new Size(43, 13);
			this.gunaLabel25.TabIndex = 1;
			this.gunaLabel25.Text = "Chance";
			this.gunaPanel28.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel28.Location = new Point(19, 177);
			this.gunaPanel28.Name = "gunaPanel28";
			this.gunaPanel28.Size = new Size(191, 2);
			this.gunaPanel28.TabIndex = 0;
			this.gunaShadowPanel6.BackColor = Color.Transparent;
			this.gunaShadowPanel6.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel6.Location = new Point(13, 155);
			this.gunaShadowPanel6.Name = "gunaShadowPanel6";
			this.gunaShadowPanel6.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel6.ShadowShift = 2;
			this.gunaShadowPanel6.Size = new Size(21, 18);
			this.gunaShadowPanel6.TabIndex = 4;
			this.gunaShadowPanel6.Click += this.gunaShadowPanel6_Click;
			this.bunifuSlider7.BackColor = Color.Transparent;
			this.bunifuSlider7.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider7.BorderRadius = 0;
			this.bunifuSlider7.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider7.Location = new Point(12, 120);
			this.bunifuSlider7.MaximumValue = 100;
			this.bunifuSlider7.Name = "bunifuSlider7";
			this.bunifuSlider7.Size = new Size(200, 30);
			this.bunifuSlider7.TabIndex = 2;
			this.bunifuSlider7.Value = 0;
			this.gunaPanel54.Controls.Add(this.gunaLabel28);
			this.gunaPanel54.Location = new Point(11, 71);
			this.gunaPanel54.Name = "gunaPanel54";
			this.gunaPanel54.Size = new Size(200, 15);
			this.gunaPanel54.TabIndex = 3;
			this.gunaLabel28.AutoSize = true;
			this.gunaLabel28.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel28.ForeColor = Color.Silver;
			this.gunaLabel28.Location = new Point(-2, 3);
			this.gunaLabel28.Name = "gunaLabel28";
			this.gunaLabel28.Size = new Size(69, 13);
			this.gunaLabel28.TabIndex = 1;
			this.gunaLabel28.Text = "MaxVelocity";
			this.bunifuSlider9.BackColor = Color.Transparent;
			this.bunifuSlider9.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider9.BorderRadius = 0;
			this.bunifuSlider9.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider9.Location = new Point(11, 78);
			this.bunifuSlider9.MaximumValue = 100;
			this.bunifuSlider9.Name = "bunifuSlider9";
			this.bunifuSlider9.Size = new Size(200, 30);
			this.bunifuSlider9.TabIndex = 2;
			this.bunifuSlider9.Value = 0;
			this.gunaPanel49.Controls.Add(this.gunaLabel26);
			this.gunaPanel49.Location = new Point(11, 32);
			this.gunaPanel49.Name = "gunaPanel49";
			this.gunaPanel49.Size = new Size(200, 15);
			this.gunaPanel49.TabIndex = 3;
			this.gunaLabel26.AutoSize = true;
			this.gunaLabel26.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel26.ForeColor = Color.Silver;
			this.gunaLabel26.Location = new Point(-2, 3);
			this.gunaLabel26.Name = "gunaLabel26";
			this.gunaLabel26.Size = new Size(66, 13);
			this.gunaLabel26.TabIndex = 1;
			this.gunaLabel26.Text = "MinVelocity";
			this.bunifuSlider8.BackColor = Color.Transparent;
			this.bunifuSlider8.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider8.BorderRadius = 0;
			this.bunifuSlider8.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider8.Location = new Point(11, 39);
			this.bunifuSlider8.MaximumValue = 100;
			this.bunifuSlider8.Name = "bunifuSlider8";
			this.bunifuSlider8.Size = new Size(200, 30);
			this.bunifuSlider8.TabIndex = 2;
			this.bunifuSlider8.Value = 0;
			this.gunaLabel27.AutoSize = true;
			this.gunaLabel27.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel27.ForeColor = Color.Silver;
			this.gunaLabel27.Location = new Point(8, 7);
			this.gunaLabel27.Name = "gunaLabel27";
			this.gunaLabel27.Size = new Size(54, 17);
			this.gunaLabel27.TabIndex = 1;
			this.gunaLabel27.Text = "Velocity";
			this.gunaPanel50.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel50.Dock = DockStyle.Left;
			this.gunaPanel50.Location = new Point(0, 2);
			this.gunaPanel50.Name = "gunaPanel50";
			this.gunaPanel50.Size = new Size(2, 230);
			this.gunaPanel50.TabIndex = 0;
			this.gunaPanel51.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel51.Dock = DockStyle.Bottom;
			this.gunaPanel51.Location = new Point(0, 232);
			this.gunaPanel51.Name = "gunaPanel51";
			this.gunaPanel51.Size = new Size(246, 2);
			this.gunaPanel51.TabIndex = 0;
			this.gunaPanel52.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel52.Dock = DockStyle.Top;
			this.gunaPanel52.Location = new Point(0, 0);
			this.gunaPanel52.Name = "gunaPanel52";
			this.gunaPanel52.Size = new Size(246, 2);
			this.gunaPanel52.TabIndex = 0;
			this.gunaPanel53.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel53.Dock = DockStyle.Right;
			this.gunaPanel53.Location = new Point(246, 0);
			this.gunaPanel53.Name = "gunaPanel53";
			this.gunaPanel53.Size = new Size(2, 234);
			this.gunaPanel53.TabIndex = 0;
			this.gunaPanel34.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel34.Controls.Add(this.bunifuDropdown1);
			this.gunaPanel34.Controls.Add(this.gunaLabel7);
			this.gunaPanel34.Controls.Add(this.gunaPanel35);
			this.gunaPanel34.Controls.Add(this.gunaPanel36);
			this.gunaPanel34.Controls.Add(this.gunaPanel37);
			this.gunaPanel34.Controls.Add(this.gunaPanel38);
			this.gunaPanel34.Controls.Add(this.gunaAdvenceButton17);
			this.gunaPanel34.Controls.Add(this.gunaPanel56);
			this.gunaPanel34.Location = new Point(533, 2);
			this.gunaPanel34.Name = "gunaPanel34";
			this.gunaPanel34.Size = new Size(140, 203);
			this.gunaPanel34.TabIndex = 0;
			this.bunifuDropdown1.BackColor = Color.Transparent;
			this.bunifuDropdown1.BorderRadius = 3;
			this.bunifuDropdown1.ForeColor = Color.Silver;
			this.bunifuDropdown1.Items = new string[]
			{
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			this.bunifuDropdown1.Location = new Point(11, 43);
			this.bunifuDropdown1.Name = "bunifuDropdown1";
			this.bunifuDropdown1.NomalColor = Color.FromArgb(8, 8, 8);
			this.bunifuDropdown1.onHoverColor = Color.FromArgb(10, 10, 10);
			this.bunifuDropdown1.selectedIndex = -1;
			this.bunifuDropdown1.Size = new Size(121, 35);
			this.bunifuDropdown1.TabIndex = 2;
			this.gunaLabel7.AutoSize = true;
			this.gunaLabel7.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel7.ForeColor = Color.Silver;
			this.gunaLabel7.Location = new Point(8, 7);
			this.gunaLabel7.Name = "gunaLabel7";
			this.gunaLabel7.Size = new Size(70, 17);
			this.gunaLabel7.TabIndex = 1;
			this.gunaLabel7.Text = "AutoBlock";
			this.gunaPanel35.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel35.Dock = DockStyle.Left;
			this.gunaPanel35.Location = new Point(0, 2);
			this.gunaPanel35.Name = "gunaPanel35";
			this.gunaPanel35.Size = new Size(2, 199);
			this.gunaPanel35.TabIndex = 0;
			this.gunaPanel36.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel36.Dock = DockStyle.Bottom;
			this.gunaPanel36.Location = new Point(0, 201);
			this.gunaPanel36.Name = "gunaPanel36";
			this.gunaPanel36.Size = new Size(138, 2);
			this.gunaPanel36.TabIndex = 0;
			this.gunaPanel37.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel37.Dock = DockStyle.Top;
			this.gunaPanel37.Location = new Point(0, 0);
			this.gunaPanel37.Name = "gunaPanel37";
			this.gunaPanel37.Size = new Size(138, 2);
			this.gunaPanel37.TabIndex = 0;
			this.gunaPanel38.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel38.Dock = DockStyle.Right;
			this.gunaPanel38.Location = new Point(138, 0);
			this.gunaPanel38.Name = "gunaPanel38";
			this.gunaPanel38.Size = new Size(2, 203);
			this.gunaPanel38.TabIndex = 0;
			this.gunaAdvenceButton17.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton17.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton17.BackColor = Color.Transparent;
			this.gunaAdvenceButton17.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton17.BorderColor = Color.Black;
			this.gunaAdvenceButton17.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton17.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton17.CheckedForeColor = Color.White;
			this.gunaAdvenceButton17.CheckedImage = null;
			this.gunaAdvenceButton17.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton17.DialogResult = DialogResult.None;
			this.gunaAdvenceButton17.FocusedColor = Color.Empty;
			this.gunaAdvenceButton17.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton17.ForeColor = Color.Silver;
			this.gunaAdvenceButton17.Image = null;
			this.gunaAdvenceButton17.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton17.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton17.Location = new Point(11, 138);
			this.gunaAdvenceButton17.Name = "gunaAdvenceButton17";
			this.gunaAdvenceButton17.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton17.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton17.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton17.OnHoverImage = null;
			this.gunaAdvenceButton17.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton17.OnPressedColor = Color.Black;
			this.gunaAdvenceButton17.Radius = 2;
			this.gunaAdvenceButton17.Size = new Size(119, 37);
			this.gunaAdvenceButton17.TabIndex = 5;
			this.gunaAdvenceButton17.Text = "Enable";
			this.gunaAdvenceButton17.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton17.Click += this.gunaAdvenceButton17_Click;
			this.gunaPanel56.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel56.Location = new Point(11, 120);
			this.gunaPanel56.Name = "gunaPanel56";
			this.gunaPanel56.Size = new Size(119, 2);
			this.gunaPanel56.TabIndex = 0;
			this.gunaAdvenceButton7.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton7.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton7.BackColor = Color.Transparent;
			this.gunaAdvenceButton7.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton7.BorderColor = Color.Black;
			this.gunaAdvenceButton7.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton7.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton7.CheckedForeColor = Color.White;
			this.gunaAdvenceButton7.CheckedImage = null;
			this.gunaAdvenceButton7.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton7.DialogResult = DialogResult.None;
			this.gunaAdvenceButton7.FocusedColor = Color.Empty;
			this.gunaAdvenceButton7.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton7.ForeColor = Color.Silver;
			this.gunaAdvenceButton7.Image = null;
			this.gunaAdvenceButton7.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton7.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton7.Location = new Point(23, 462);
			this.gunaAdvenceButton7.Name = "gunaAdvenceButton7";
			this.gunaAdvenceButton7.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton7.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton7.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton7.OnHoverImage = null;
			this.gunaAdvenceButton7.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton7.OnPressedColor = Color.Black;
			this.gunaAdvenceButton7.Radius = 2;
			this.gunaAdvenceButton7.Size = new Size(96, 37);
			this.gunaAdvenceButton7.TabIndex = 5;
			this.gunaAdvenceButton7.Text = "SaveSettings";
			this.gunaAdvenceButton7.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton7.Click += this.gunaAdvenceButton7_Click;
			this.gunaAdvenceButton14.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton14.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton14.BackColor = Color.Transparent;
			this.gunaAdvenceButton14.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton14.BorderColor = Color.Black;
			this.gunaAdvenceButton14.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton14.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton14.CheckedForeColor = Color.White;
			this.gunaAdvenceButton14.CheckedImage = null;
			this.gunaAdvenceButton14.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton14.DialogResult = DialogResult.None;
			this.gunaAdvenceButton14.FocusedColor = Color.Empty;
			this.gunaAdvenceButton14.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton14.ForeColor = Color.Silver;
			this.gunaAdvenceButton14.Image = null;
			this.gunaAdvenceButton14.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton14.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton14.Location = new Point(330, 462);
			this.gunaAdvenceButton14.Name = "gunaAdvenceButton14";
			this.gunaAdvenceButton14.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton14.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton14.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton14.OnHoverImage = null;
			this.gunaAdvenceButton14.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton14.OnPressedColor = Color.Black;
			this.gunaAdvenceButton14.Radius = 2;
			this.gunaAdvenceButton14.Size = new Size(96, 37);
			this.gunaAdvenceButton14.TabIndex = 5;
			this.gunaAdvenceButton14.Text = "BlatantSettings";
			this.gunaAdvenceButton14.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton14.Click += this.gunaAdvenceButton14_Click;
			this.gunaAdvenceButton8.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton8.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton8.BackColor = Color.Transparent;
			this.gunaAdvenceButton8.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton8.BorderColor = Color.Black;
			this.gunaAdvenceButton8.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton8.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton8.CheckedForeColor = Color.White;
			this.gunaAdvenceButton8.CheckedImage = null;
			this.gunaAdvenceButton8.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton8.DialogResult = DialogResult.None;
			this.gunaAdvenceButton8.FocusedColor = Color.Empty;
			this.gunaAdvenceButton8.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton8.ForeColor = Color.Silver;
			this.gunaAdvenceButton8.Image = null;
			this.gunaAdvenceButton8.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton8.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton8.Location = new Point(125, 462);
			this.gunaAdvenceButton8.Name = "gunaAdvenceButton8";
			this.gunaAdvenceButton8.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton8.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton8.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton8.OnHoverImage = null;
			this.gunaAdvenceButton8.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton8.OnPressedColor = Color.Black;
			this.gunaAdvenceButton8.Radius = 2;
			this.gunaAdvenceButton8.Size = new Size(96, 37);
			this.gunaAdvenceButton8.TabIndex = 5;
			this.gunaAdvenceButton8.Text = "ResetSettings";
			this.gunaAdvenceButton8.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton8.Click += this.gunaAdvenceButton8_Click;
			this.gunaAdvenceButton13.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton13.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton13.BackColor = Color.Transparent;
			this.gunaAdvenceButton13.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton13.BorderColor = Color.Black;
			this.gunaAdvenceButton13.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton13.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton13.CheckedForeColor = Color.White;
			this.gunaAdvenceButton13.CheckedImage = null;
			this.gunaAdvenceButton13.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton13.DialogResult = DialogResult.None;
			this.gunaAdvenceButton13.FocusedColor = Color.Empty;
			this.gunaAdvenceButton13.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton13.ForeColor = Color.Silver;
			this.gunaAdvenceButton13.Image = null;
			this.gunaAdvenceButton13.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton13.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton13.Location = new Point(228, 462);
			this.gunaAdvenceButton13.Name = "gunaAdvenceButton13";
			this.gunaAdvenceButton13.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton13.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton13.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton13.OnHoverImage = null;
			this.gunaAdvenceButton13.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton13.OnPressedColor = Color.Black;
			this.gunaAdvenceButton13.Radius = 2;
			this.gunaAdvenceButton13.Size = new Size(96, 37);
			this.gunaAdvenceButton13.TabIndex = 5;
			this.gunaAdvenceButton13.Text = "LegitSettings";
			this.gunaAdvenceButton13.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton13.Click += this.gunaAdvenceButton13_Click;
			this.tabPage2.BackColor = Color.FromArgb(15, 15, 15);
			this.tabPage2.Controls.Add(this.gunaTextBox9);
			this.tabPage2.Controls.Add(this.gunaTextBox8);
			this.tabPage2.Controls.Add(this.gunaPanel84);
			this.tabPage2.Controls.Add(this.gunaPanel143);
			this.tabPage2.Controls.Add(this.gunaPanel82);
			this.tabPage2.Controls.Add(this.gunaPanel72);
			this.tabPage2.Controls.Add(this.gunaPanel94);
			this.tabPage2.Controls.Add(this.gunaPanel62);
			this.tabPage2.Location = new Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new Padding(3);
			this.tabPage2.Size = new Size(691, 508);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.Click += this.tabPage2_Click;
			this.gunaTextBox9.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox9.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox9.Cursor = Cursors.IBeam;
			this.gunaTextBox9.Enabled = false;
			this.gunaTextBox9.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox9.FocusedBorderColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox9.FocusedForeColor = Color.Silver;
			this.gunaTextBox9.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox9.ForeColor = Color.Silver;
			this.gunaTextBox9.Location = new Point(388, 341);
			this.gunaTextBox9.Name = "gunaTextBox9";
			this.gunaTextBox9.PasswordChar = '\0';
			this.gunaTextBox9.SelectedText = "";
			this.gunaTextBox9.Size = new Size(96, 37);
			this.gunaTextBox9.TabIndex = 8;
			this.gunaTextBox9.Text = "E";
			this.gunaTextBox9.TextAlign = HorizontalAlignment.Center;
			this.gunaTextBox9.Visible = false;
			this.gunaTextBox9.TextChanged += this.gunaTextBox8_TextChanged;
			this.gunaTextBox8.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox8.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox8.Cursor = Cursors.IBeam;
			this.gunaTextBox8.Enabled = false;
			this.gunaTextBox8.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox8.FocusedBorderColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox8.FocusedForeColor = Color.Silver;
			this.gunaTextBox8.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox8.ForeColor = Color.Silver;
			this.gunaTextBox8.Location = new Point(286, 341);
			this.gunaTextBox8.Name = "gunaTextBox8";
			this.gunaTextBox8.PasswordChar = '\0';
			this.gunaTextBox8.SelectedText = "";
			this.gunaTextBox8.Size = new Size(96, 37);
			this.gunaTextBox8.TabIndex = 8;
			this.gunaTextBox8.Text = "W";
			this.gunaTextBox8.TextAlign = HorizontalAlignment.Center;
			this.gunaTextBox8.Visible = false;
			this.gunaTextBox8.TextChanged += this.gunaTextBox8_TextChanged;
			this.gunaPanel84.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel84.Controls.Add(this.gunaLabel45);
			this.gunaPanel84.Controls.Add(this.gunaShadowPanel8);
			this.gunaPanel84.Controls.Add(this.gunaAdvenceButton22);
			this.gunaPanel84.Controls.Add(this.gunaPanel85);
			this.gunaPanel84.Controls.Add(this.gunaLabel46);
			this.gunaPanel84.Controls.Add(this.gunaPanel86);
			this.gunaPanel84.Controls.Add(this.gunaPanel87);
			this.gunaPanel84.Controls.Add(this.gunaPanel92);
			this.gunaPanel84.Controls.Add(this.gunaPanel93);
			this.gunaPanel84.Location = new Point(286, 196);
			this.gunaPanel84.Name = "gunaPanel84";
			this.gunaPanel84.Size = new Size(248, 137);
			this.gunaPanel84.TabIndex = 1;
			this.gunaPanel84.Paint += this.gunaPanel84_Paint;
			this.gunaLabel45.AutoSize = true;
			this.gunaLabel45.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel45.ForeColor = Color.Silver;
			this.gunaLabel45.Location = new Point(39, 35);
			this.gunaLabel45.Name = "gunaLabel45";
			this.gunaLabel45.Size = new Size(85, 13);
			this.gunaLabel45.TabIndex = 6;
			this.gunaLabel45.Text = "Random Speed";
			this.gunaLabel45.Visible = false;
			this.gunaLabel45.Click += this.gunaLabel45_Click;
			this.gunaShadowPanel8.BackColor = Color.Transparent;
			this.gunaShadowPanel8.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel8.Location = new Point(12, 30);
			this.gunaShadowPanel8.Name = "gunaShadowPanel8";
			this.gunaShadowPanel8.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel8.ShadowShift = 2;
			this.gunaShadowPanel8.Size = new Size(21, 18);
			this.gunaShadowPanel8.TabIndex = 7;
			this.gunaShadowPanel8.Visible = false;
			this.gunaAdvenceButton22.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton22.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton22.BackColor = Color.Transparent;
			this.gunaAdvenceButton22.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton22.BorderColor = Color.Black;
			this.gunaAdvenceButton22.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton22.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton22.CheckedForeColor = Color.White;
			this.gunaAdvenceButton22.CheckedImage = null;
			this.gunaAdvenceButton22.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton22.DialogResult = DialogResult.None;
			this.gunaAdvenceButton22.FocusedColor = Color.Empty;
			this.gunaAdvenceButton22.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton22.ForeColor = Color.Silver;
			this.gunaAdvenceButton22.Image = null;
			this.gunaAdvenceButton22.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton22.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton22.Location = new Point(12, 74);
			this.gunaAdvenceButton22.Name = "gunaAdvenceButton22";
			this.gunaAdvenceButton22.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton22.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton22.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton22.OnHoverImage = null;
			this.gunaAdvenceButton22.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton22.OnPressedColor = Color.Black;
			this.gunaAdvenceButton22.Radius = 2;
			this.gunaAdvenceButton22.Size = new Size(192, 37);
			this.gunaAdvenceButton22.TabIndex = 5;
			this.gunaAdvenceButton22.Text = "Enable";
			this.gunaAdvenceButton22.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton22.Visible = false;
			this.gunaPanel85.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel85.Location = new Point(13, 63);
			this.gunaPanel85.Name = "gunaPanel85";
			this.gunaPanel85.Size = new Size(191, 2);
			this.gunaPanel85.TabIndex = 0;
			this.gunaPanel85.Visible = false;
			this.gunaLabel46.AutoSize = true;
			this.gunaLabel46.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel46.ForeColor = Color.Silver;
			this.gunaLabel46.Location = new Point(8, 7);
			this.gunaLabel46.Name = "gunaLabel46";
			this.gunaLabel46.Size = new Size(42, 17);
			this.gunaLabel46.TabIndex = 1;
			this.gunaLabel46.Text = "Timer";
			this.gunaPanel86.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel86.Dock = DockStyle.Left;
			this.gunaPanel86.Location = new Point(0, 2);
			this.gunaPanel86.Name = "gunaPanel86";
			this.gunaPanel86.Size = new Size(2, 133);
			this.gunaPanel86.TabIndex = 0;
			this.gunaPanel87.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel87.Dock = DockStyle.Bottom;
			this.gunaPanel87.Location = new Point(0, 135);
			this.gunaPanel87.Name = "gunaPanel87";
			this.gunaPanel87.Size = new Size(246, 2);
			this.gunaPanel87.TabIndex = 0;
			this.gunaPanel92.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel92.Dock = DockStyle.Top;
			this.gunaPanel92.Location = new Point(0, 0);
			this.gunaPanel92.Name = "gunaPanel92";
			this.gunaPanel92.Size = new Size(246, 2);
			this.gunaPanel92.TabIndex = 0;
			this.gunaPanel93.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel93.Dock = DockStyle.Right;
			this.gunaPanel93.Location = new Point(246, 0);
			this.gunaPanel93.Name = "gunaPanel93";
			this.gunaPanel93.Size = new Size(2, 137);
			this.gunaPanel93.TabIndex = 0;
			this.gunaPanel143.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel143.Controls.Add(this.gunaLabel71);
			this.gunaPanel143.Controls.Add(this.gunaShadowPanel17);
			this.gunaPanel143.Controls.Add(this.gunaAdvenceButton2);
			this.gunaPanel143.Controls.Add(this.gunaPanel145);
			this.gunaPanel143.Controls.Add(this.gunaLabel72);
			this.gunaPanel143.Controls.Add(this.gunaPanel146);
			this.gunaPanel143.Controls.Add(this.gunaPanel147);
			this.gunaPanel143.Controls.Add(this.gunaPanel148);
			this.gunaPanel143.Controls.Add(this.gunaPanel149);
			this.gunaPanel143.Location = new Point(22, 339);
			this.gunaPanel143.Name = "gunaPanel143";
			this.gunaPanel143.Size = new Size(248, 137);
			this.gunaPanel143.TabIndex = 1;
			this.gunaLabel71.AutoSize = true;
			this.gunaLabel71.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel71.ForeColor = Color.Silver;
			this.gunaLabel71.Location = new Point(39, 35);
			this.gunaLabel71.Name = "gunaLabel71";
			this.gunaLabel71.Size = new Size(85, 13);
			this.gunaLabel71.TabIndex = 6;
			this.gunaLabel71.Text = "Random Speed";
			this.gunaLabel71.Click += this.gunaLabel71_Click;
			this.gunaShadowPanel17.BackColor = Color.Transparent;
			this.gunaShadowPanel17.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel17.Location = new Point(12, 30);
			this.gunaShadowPanel17.Name = "gunaShadowPanel17";
			this.gunaShadowPanel17.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel17.ShadowShift = 2;
			this.gunaShadowPanel17.Size = new Size(21, 18);
			this.gunaShadowPanel17.TabIndex = 7;
			this.gunaShadowPanel17.Click += this.gunaShadowPanel17_Click;
			this.gunaAdvenceButton2.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton2.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton2.BackColor = Color.Transparent;
			this.gunaAdvenceButton2.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton2.BorderColor = Color.Black;
			this.gunaAdvenceButton2.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton2.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton2.CheckedForeColor = Color.White;
			this.gunaAdvenceButton2.CheckedImage = null;
			this.gunaAdvenceButton2.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton2.DialogResult = DialogResult.None;
			this.gunaAdvenceButton2.FocusedColor = Color.Empty;
			this.gunaAdvenceButton2.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton2.ForeColor = Color.Silver;
			this.gunaAdvenceButton2.Image = null;
			this.gunaAdvenceButton2.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton2.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton2.Location = new Point(12, 74);
			this.gunaAdvenceButton2.Name = "gunaAdvenceButton2";
			this.gunaAdvenceButton2.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton2.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton2.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton2.OnHoverImage = null;
			this.gunaAdvenceButton2.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton2.OnPressedColor = Color.Black;
			this.gunaAdvenceButton2.Radius = 2;
			this.gunaAdvenceButton2.Size = new Size(192, 37);
			this.gunaAdvenceButton2.TabIndex = 5;
			this.gunaAdvenceButton2.Text = "Enable";
			this.gunaAdvenceButton2.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton2.Click += this.gunaAdvenceButton2_Click;
			this.gunaPanel145.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel145.Location = new Point(13, 63);
			this.gunaPanel145.Name = "gunaPanel145";
			this.gunaPanel145.Size = new Size(191, 2);
			this.gunaPanel145.TabIndex = 0;
			this.gunaLabel72.AutoSize = true;
			this.gunaLabel72.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel72.ForeColor = Color.Silver;
			this.gunaLabel72.Location = new Point(8, 7);
			this.gunaLabel72.Name = "gunaLabel72";
			this.gunaLabel72.Size = new Size(64, 17);
			this.gunaLabel72.TabIndex = 1;
			this.gunaLabel72.Text = "FastPlace";
			this.gunaPanel146.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel146.Dock = DockStyle.Left;
			this.gunaPanel146.Location = new Point(0, 2);
			this.gunaPanel146.Name = "gunaPanel146";
			this.gunaPanel146.Size = new Size(2, 133);
			this.gunaPanel146.TabIndex = 0;
			this.gunaPanel147.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel147.Dock = DockStyle.Bottom;
			this.gunaPanel147.Location = new Point(0, 135);
			this.gunaPanel147.Name = "gunaPanel147";
			this.gunaPanel147.Size = new Size(246, 2);
			this.gunaPanel147.TabIndex = 0;
			this.gunaPanel148.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel148.Dock = DockStyle.Top;
			this.gunaPanel148.Location = new Point(0, 0);
			this.gunaPanel148.Name = "gunaPanel148";
			this.gunaPanel148.Size = new Size(246, 2);
			this.gunaPanel148.TabIndex = 0;
			this.gunaPanel149.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel149.Dock = DockStyle.Right;
			this.gunaPanel149.Location = new Point(246, 0);
			this.gunaPanel149.Name = "gunaPanel149";
			this.gunaPanel149.Size = new Size(2, 137);
			this.gunaPanel149.TabIndex = 0;
			this.gunaPanel82.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel82.Controls.Add(this.gunaLabel44);
			this.gunaPanel82.Controls.Add(this.gunaShadowPanel7);
			this.gunaPanel82.Controls.Add(this.gunaAdvenceButton21);
			this.gunaPanel82.Controls.Add(this.gunaPanel83);
			this.gunaPanel82.Controls.Add(this.gunaLabel48);
			this.gunaPanel82.Controls.Add(this.gunaPanel88);
			this.gunaPanel82.Controls.Add(this.gunaPanel89);
			this.gunaPanel82.Controls.Add(this.gunaPanel90);
			this.gunaPanel82.Controls.Add(this.gunaPanel91);
			this.gunaPanel82.Location = new Point(22, 196);
			this.gunaPanel82.Name = "gunaPanel82";
			this.gunaPanel82.Size = new Size(248, 137);
			this.gunaPanel82.TabIndex = 1;
			this.gunaLabel44.AutoSize = true;
			this.gunaLabel44.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel44.ForeColor = Color.Silver;
			this.gunaLabel44.Location = new Point(39, 35);
			this.gunaLabel44.Name = "gunaLabel44";
			this.gunaLabel44.Size = new Size(85, 13);
			this.gunaLabel44.TabIndex = 6;
			this.gunaLabel44.Text = "Random Speed";
			this.gunaLabel44.Click += this.gunaLabel44_Click;
			this.gunaShadowPanel7.BackColor = Color.Transparent;
			this.gunaShadowPanel7.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel7.Location = new Point(12, 30);
			this.gunaShadowPanel7.Name = "gunaShadowPanel7";
			this.gunaShadowPanel7.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel7.ShadowShift = 2;
			this.gunaShadowPanel7.Size = new Size(21, 18);
			this.gunaShadowPanel7.TabIndex = 7;
			this.gunaShadowPanel7.Click += this.gunaShadowPanel7_Click;
			this.gunaAdvenceButton21.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton21.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton21.BackColor = Color.Transparent;
			this.gunaAdvenceButton21.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton21.BorderColor = Color.Black;
			this.gunaAdvenceButton21.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton21.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton21.CheckedForeColor = Color.White;
			this.gunaAdvenceButton21.CheckedImage = null;
			this.gunaAdvenceButton21.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton21.DialogResult = DialogResult.None;
			this.gunaAdvenceButton21.FocusedColor = Color.Empty;
			this.gunaAdvenceButton21.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton21.ForeColor = Color.Silver;
			this.gunaAdvenceButton21.Image = null;
			this.gunaAdvenceButton21.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton21.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton21.Location = new Point(12, 74);
			this.gunaAdvenceButton21.Name = "gunaAdvenceButton21";
			this.gunaAdvenceButton21.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton21.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton21.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton21.OnHoverImage = null;
			this.gunaAdvenceButton21.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton21.OnPressedColor = Color.Black;
			this.gunaAdvenceButton21.Radius = 2;
			this.gunaAdvenceButton21.Size = new Size(192, 37);
			this.gunaAdvenceButton21.TabIndex = 5;
			this.gunaAdvenceButton21.Text = "Enable";
			this.gunaAdvenceButton21.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton21.Click += this.gunaAdvenceButton21_Click;
			this.gunaPanel83.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel83.Location = new Point(13, 63);
			this.gunaPanel83.Name = "gunaPanel83";
			this.gunaPanel83.Size = new Size(191, 2);
			this.gunaPanel83.TabIndex = 0;
			this.gunaLabel48.AutoSize = true;
			this.gunaLabel48.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel48.ForeColor = Color.Silver;
			this.gunaLabel48.Location = new Point(8, 7);
			this.gunaLabel48.Name = "gunaLabel48";
			this.gunaLabel48.Size = new Size(44, 17);
			this.gunaLabel48.TabIndex = 1;
			this.gunaLabel48.Text = "Sprint";
			this.gunaPanel88.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel88.Dock = DockStyle.Left;
			this.gunaPanel88.Location = new Point(0, 2);
			this.gunaPanel88.Name = "gunaPanel88";
			this.gunaPanel88.Size = new Size(2, 133);
			this.gunaPanel88.TabIndex = 0;
			this.gunaPanel89.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel89.Dock = DockStyle.Bottom;
			this.gunaPanel89.Location = new Point(0, 135);
			this.gunaPanel89.Name = "gunaPanel89";
			this.gunaPanel89.Size = new Size(246, 2);
			this.gunaPanel89.TabIndex = 0;
			this.gunaPanel90.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel90.Dock = DockStyle.Top;
			this.gunaPanel90.Location = new Point(0, 0);
			this.gunaPanel90.Name = "gunaPanel90";
			this.gunaPanel90.Size = new Size(246, 2);
			this.gunaPanel90.TabIndex = 0;
			this.gunaPanel91.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel91.Dock = DockStyle.Right;
			this.gunaPanel91.Location = new Point(246, 0);
			this.gunaPanel91.Name = "gunaPanel91";
			this.gunaPanel91.Size = new Size(2, 137);
			this.gunaPanel91.TabIndex = 0;
			this.gunaPanel72.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel72.Controls.Add(this.gunaAdvenceButton19);
			this.gunaPanel72.Controls.Add(this.gunaPanel73);
			this.gunaPanel72.Controls.Add(this.gunaLabel34);
			this.gunaPanel72.Controls.Add(this.gunaLabel35);
			this.gunaPanel72.Controls.Add(this.gunaPanel74);
			this.gunaPanel72.Controls.Add(this.gunaPanel75);
			this.gunaPanel72.Controls.Add(this.gunaPanel76);
			this.gunaPanel72.Controls.Add(this.bunifuSlider12);
			this.gunaPanel72.Controls.Add(this.gunaPanel77);
			this.gunaPanel72.Controls.Add(this.bunifuSlider13);
			this.gunaPanel72.Controls.Add(this.gunaLabel43);
			this.gunaPanel72.Controls.Add(this.gunaPanel78);
			this.gunaPanel72.Controls.Add(this.gunaPanel79);
			this.gunaPanel72.Controls.Add(this.gunaPanel80);
			this.gunaPanel72.Controls.Add(this.gunaPanel81);
			this.gunaPanel72.Location = new Point(286, 2);
			this.gunaPanel72.Name = "gunaPanel72";
			this.gunaPanel72.Size = new Size(248, 188);
			this.gunaPanel72.TabIndex = 1;
			this.gunaAdvenceButton19.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton19.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton19.BackColor = Color.Transparent;
			this.gunaAdvenceButton19.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton19.BorderColor = Color.Black;
			this.gunaAdvenceButton19.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton19.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton19.CheckedForeColor = Color.White;
			this.gunaAdvenceButton19.CheckedImage = null;
			this.gunaAdvenceButton19.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton19.DialogResult = DialogResult.None;
			this.gunaAdvenceButton19.FocusedColor = Color.Empty;
			this.gunaAdvenceButton19.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton19.ForeColor = Color.Silver;
			this.gunaAdvenceButton19.Image = null;
			this.gunaAdvenceButton19.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton19.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton19.Location = new Point(12, 133);
			this.gunaAdvenceButton19.Name = "gunaAdvenceButton19";
			this.gunaAdvenceButton19.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton19.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton19.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton19.OnHoverImage = null;
			this.gunaAdvenceButton19.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton19.OnPressedColor = Color.Black;
			this.gunaAdvenceButton19.Radius = 2;
			this.gunaAdvenceButton19.Size = new Size(192, 37);
			this.gunaAdvenceButton19.TabIndex = 5;
			this.gunaAdvenceButton19.Text = "Enable";
			this.gunaAdvenceButton19.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton19.Click += this.gunaAdvenceButton19_Click;
			this.gunaPanel73.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel73.Location = new Point(13, 122);
			this.gunaPanel73.Name = "gunaPanel73";
			this.gunaPanel73.Size = new Size(191, 2);
			this.gunaPanel73.TabIndex = 0;
			this.gunaLabel34.AutoSize = true;
			this.gunaLabel34.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel34.ForeColor = Color.Silver;
			this.gunaLabel34.Location = new Point(211, 88);
			this.gunaLabel34.Name = "gunaLabel34";
			this.gunaLabel34.Size = new Size(13, 13);
			this.gunaLabel34.TabIndex = 1;
			this.gunaLabel34.Text = "0";
			this.gunaLabel34.Click += this.gunaLabel34_Click;
			this.gunaLabel35.AutoSize = true;
			this.gunaLabel35.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel35.ForeColor = Color.Silver;
			this.gunaLabel35.Location = new Point(210, 43);
			this.gunaLabel35.Name = "gunaLabel35";
			this.gunaLabel35.Size = new Size(13, 13);
			this.gunaLabel35.TabIndex = 1;
			this.gunaLabel35.Text = "0";
			this.gunaPanel74.Location = new Point(11, 99);
			this.gunaPanel74.Name = "gunaPanel74";
			this.gunaPanel74.Size = new Size(200, 15);
			this.gunaPanel74.TabIndex = 3;
			this.gunaPanel75.Location = new Point(11, 56);
			this.gunaPanel75.Name = "gunaPanel75";
			this.gunaPanel75.Size = new Size(200, 15);
			this.gunaPanel75.TabIndex = 3;
			this.gunaPanel76.Controls.Add(this.gunaLabel36);
			this.gunaPanel76.Location = new Point(11, 75);
			this.gunaPanel76.Name = "gunaPanel76";
			this.gunaPanel76.Size = new Size(200, 15);
			this.gunaPanel76.TabIndex = 3;
			this.gunaLabel36.AutoSize = true;
			this.gunaLabel36.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel36.ForeColor = Color.Silver;
			this.gunaLabel36.Location = new Point(-2, 3);
			this.gunaLabel36.Name = "gunaLabel36";
			this.gunaLabel36.Size = new Size(87, 13);
			this.gunaLabel36.TabIndex = 1;
			this.gunaLabel36.Text = "MaximumDelay";
			this.bunifuSlider12.BackColor = Color.Transparent;
			this.bunifuSlider12.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider12.BorderRadius = 0;
			this.bunifuSlider12.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider12.Location = new Point(11, 82);
			this.bunifuSlider12.MaximumValue = 500;
			this.bunifuSlider12.Name = "bunifuSlider12";
			this.bunifuSlider12.Size = new Size(200, 30);
			this.bunifuSlider12.TabIndex = 2;
			this.bunifuSlider12.Value = 20;
			this.gunaPanel77.Controls.Add(this.gunaLabel37);
			this.gunaPanel77.Location = new Point(11, 32);
			this.gunaPanel77.Name = "gunaPanel77";
			this.gunaPanel77.Size = new Size(200, 15);
			this.gunaPanel77.TabIndex = 3;
			this.gunaLabel37.AutoSize = true;
			this.gunaLabel37.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel37.ForeColor = Color.Silver;
			this.gunaLabel37.Location = new Point(-2, 3);
			this.gunaLabel37.Name = "gunaLabel37";
			this.gunaLabel37.Size = new Size(84, 13);
			this.gunaLabel37.TabIndex = 1;
			this.gunaLabel37.Text = "MinimumDelay";
			this.bunifuSlider13.BackColor = Color.Transparent;
			this.bunifuSlider13.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider13.BorderRadius = 0;
			this.bunifuSlider13.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider13.Location = new Point(11, 39);
			this.bunifuSlider13.MaximumValue = 500;
			this.bunifuSlider13.Name = "bunifuSlider13";
			this.bunifuSlider13.Size = new Size(200, 30);
			this.bunifuSlider13.TabIndex = 2;
			this.bunifuSlider13.Value = 0;
			this.gunaLabel43.AutoSize = true;
			this.gunaLabel43.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel43.ForeColor = Color.Silver;
			this.gunaLabel43.Location = new Point(8, 7);
			this.gunaLabel43.Name = "gunaLabel43";
			this.gunaLabel43.Size = new Size(41, 17);
			this.gunaLabel43.TabIndex = 1;
			this.gunaLabel43.Text = "S-Tap";
			this.gunaPanel78.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel78.Dock = DockStyle.Left;
			this.gunaPanel78.Location = new Point(0, 2);
			this.gunaPanel78.Name = "gunaPanel78";
			this.gunaPanel78.Size = new Size(2, 184);
			this.gunaPanel78.TabIndex = 0;
			this.gunaPanel79.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel79.Dock = DockStyle.Bottom;
			this.gunaPanel79.Location = new Point(0, 186);
			this.gunaPanel79.Name = "gunaPanel79";
			this.gunaPanel79.Size = new Size(246, 2);
			this.gunaPanel79.TabIndex = 0;
			this.gunaPanel80.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel80.Dock = DockStyle.Top;
			this.gunaPanel80.Location = new Point(0, 0);
			this.gunaPanel80.Name = "gunaPanel80";
			this.gunaPanel80.Size = new Size(246, 2);
			this.gunaPanel80.TabIndex = 0;
			this.gunaPanel81.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel81.Dock = DockStyle.Right;
			this.gunaPanel81.Location = new Point(246, 0);
			this.gunaPanel81.Name = "gunaPanel81";
			this.gunaPanel81.Size = new Size(2, 188);
			this.gunaPanel81.TabIndex = 0;
			this.gunaPanel94.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel94.Controls.Add(this.gunaAdvenceButton23);
			this.gunaPanel94.Controls.Add(this.gunaPanel95);
			this.gunaPanel94.Controls.Add(this.gunaLabel47);
			this.gunaPanel94.Controls.Add(this.gunaLabel49);
			this.gunaPanel94.Controls.Add(this.gunaLabel52);
			this.gunaPanel94.Controls.Add(this.gunaPanel100);
			this.gunaPanel94.Controls.Add(this.gunaPanel101);
			this.gunaPanel94.Controls.Add(this.gunaPanel102);
			this.gunaPanel94.Controls.Add(this.gunaPanel103);
			this.gunaPanel94.Location = new Point(540, 2);
			this.gunaPanel94.Name = "gunaPanel94";
			this.gunaPanel94.Size = new Size(140, 188);
			this.gunaPanel94.TabIndex = 1;
			this.gunaAdvenceButton23.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton23.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton23.BackColor = Color.Transparent;
			this.gunaAdvenceButton23.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton23.BorderColor = Color.Black;
			this.gunaAdvenceButton23.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton23.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton23.CheckedForeColor = Color.White;
			this.gunaAdvenceButton23.CheckedImage = null;
			this.gunaAdvenceButton23.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton23.DialogResult = DialogResult.None;
			this.gunaAdvenceButton23.FocusedColor = Color.Empty;
			this.gunaAdvenceButton23.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton23.ForeColor = Color.Silver;
			this.gunaAdvenceButton23.Image = null;
			this.gunaAdvenceButton23.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton23.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton23.Location = new Point(13, 133);
			this.gunaAdvenceButton23.Name = "gunaAdvenceButton23";
			this.gunaAdvenceButton23.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton23.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton23.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton23.OnHoverImage = null;
			this.gunaAdvenceButton23.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton23.OnPressedColor = Color.Black;
			this.gunaAdvenceButton23.Radius = 2;
			this.gunaAdvenceButton23.Size = new Size(111, 37);
			this.gunaAdvenceButton23.TabIndex = 5;
			this.gunaAdvenceButton23.Text = "Enable";
			this.gunaAdvenceButton23.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton23.Click += this.gunaAdvenceButton23_Click;
			this.gunaPanel95.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel95.Location = new Point(13, 122);
			this.gunaPanel95.Name = "gunaPanel95";
			this.gunaPanel95.Size = new Size(109, 2);
			this.gunaPanel95.TabIndex = 0;
			this.gunaLabel47.AutoSize = true;
			this.gunaLabel47.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel47.ForeColor = Color.Silver;
			this.gunaLabel47.Location = new Point(221, 88);
			this.gunaLabel47.Name = "gunaLabel47";
			this.gunaLabel47.Size = new Size(13, 13);
			this.gunaLabel47.TabIndex = 1;
			this.gunaLabel47.Text = "0";
			this.gunaLabel49.AutoSize = true;
			this.gunaLabel49.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel49.ForeColor = Color.Silver;
			this.gunaLabel49.Location = new Point(221, 43);
			this.gunaLabel49.Name = "gunaLabel49";
			this.gunaLabel49.Size = new Size(13, 13);
			this.gunaLabel49.TabIndex = 1;
			this.gunaLabel49.Text = "0";
			this.gunaLabel52.AutoSize = true;
			this.gunaLabel52.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel52.ForeColor = Color.Silver;
			this.gunaLabel52.Location = new Point(8, 7);
			this.gunaLabel52.Name = "gunaLabel52";
			this.gunaLabel52.Size = new Size(57, 17);
			this.gunaLabel52.TabIndex = 1;
			this.gunaLabel52.Text = "AntiAFK";
			this.gunaPanel100.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel100.Dock = DockStyle.Left;
			this.gunaPanel100.Location = new Point(0, 2);
			this.gunaPanel100.Name = "gunaPanel100";
			this.gunaPanel100.Size = new Size(2, 184);
			this.gunaPanel100.TabIndex = 0;
			this.gunaPanel101.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel101.Dock = DockStyle.Bottom;
			this.gunaPanel101.Location = new Point(0, 186);
			this.gunaPanel101.Name = "gunaPanel101";
			this.gunaPanel101.Size = new Size(138, 2);
			this.gunaPanel101.TabIndex = 0;
			this.gunaPanel102.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel102.Dock = DockStyle.Top;
			this.gunaPanel102.Location = new Point(0, 0);
			this.gunaPanel102.Name = "gunaPanel102";
			this.gunaPanel102.Size = new Size(138, 2);
			this.gunaPanel102.TabIndex = 0;
			this.gunaPanel103.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel103.Dock = DockStyle.Right;
			this.gunaPanel103.Location = new Point(138, 0);
			this.gunaPanel103.Name = "gunaPanel103";
			this.gunaPanel103.Size = new Size(2, 188);
			this.gunaPanel103.TabIndex = 0;
			this.gunaPanel62.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel62.Controls.Add(this.gunaAdvenceButton20);
			this.gunaPanel62.Controls.Add(this.gunaPanel63);
			this.gunaPanel62.Controls.Add(this.gunaLabel38);
			this.gunaPanel62.Controls.Add(this.gunaLabel39);
			this.gunaPanel62.Controls.Add(this.gunaPanel64);
			this.gunaPanel62.Controls.Add(this.gunaPanel65);
			this.gunaPanel62.Controls.Add(this.gunaPanel66);
			this.gunaPanel62.Controls.Add(this.bunifuSlider10);
			this.gunaPanel62.Controls.Add(this.gunaPanel67);
			this.gunaPanel62.Controls.Add(this.bunifuSlider11);
			this.gunaPanel62.Controls.Add(this.gunaLabel42);
			this.gunaPanel62.Controls.Add(this.gunaPanel68);
			this.gunaPanel62.Controls.Add(this.gunaPanel69);
			this.gunaPanel62.Controls.Add(this.gunaPanel70);
			this.gunaPanel62.Controls.Add(this.gunaPanel71);
			this.gunaPanel62.Location = new Point(22, 2);
			this.gunaPanel62.Name = "gunaPanel62";
			this.gunaPanel62.Size = new Size(248, 188);
			this.gunaPanel62.TabIndex = 1;
			this.gunaAdvenceButton20.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton20.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton20.BackColor = Color.Transparent;
			this.gunaAdvenceButton20.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton20.BorderColor = Color.Black;
			this.gunaAdvenceButton20.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton20.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton20.CheckedForeColor = Color.White;
			this.gunaAdvenceButton20.CheckedImage = null;
			this.gunaAdvenceButton20.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton20.DialogResult = DialogResult.None;
			this.gunaAdvenceButton20.FocusedColor = Color.Empty;
			this.gunaAdvenceButton20.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton20.ForeColor = Color.Silver;
			this.gunaAdvenceButton20.Image = null;
			this.gunaAdvenceButton20.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton20.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton20.Location = new Point(12, 133);
			this.gunaAdvenceButton20.Name = "gunaAdvenceButton20";
			this.gunaAdvenceButton20.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton20.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton20.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton20.OnHoverImage = null;
			this.gunaAdvenceButton20.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton20.OnPressedColor = Color.Black;
			this.gunaAdvenceButton20.Radius = 2;
			this.gunaAdvenceButton20.Size = new Size(192, 37);
			this.gunaAdvenceButton20.TabIndex = 5;
			this.gunaAdvenceButton20.Text = "Enable";
			this.gunaAdvenceButton20.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton20.Click += this.gunaAdvenceButton20_Click;
			this.gunaPanel63.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel63.Location = new Point(13, 122);
			this.gunaPanel63.Name = "gunaPanel63";
			this.gunaPanel63.Size = new Size(191, 2);
			this.gunaPanel63.TabIndex = 0;
			this.gunaLabel38.AutoSize = true;
			this.gunaLabel38.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel38.ForeColor = Color.Silver;
			this.gunaLabel38.Location = new Point(210, 88);
			this.gunaLabel38.Name = "gunaLabel38";
			this.gunaLabel38.Size = new Size(13, 13);
			this.gunaLabel38.TabIndex = 1;
			this.gunaLabel38.Text = "0";
			this.gunaLabel39.AutoSize = true;
			this.gunaLabel39.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel39.ForeColor = Color.Silver;
			this.gunaLabel39.Location = new Point(210, 44);
			this.gunaLabel39.Name = "gunaLabel39";
			this.gunaLabel39.Size = new Size(13, 13);
			this.gunaLabel39.TabIndex = 1;
			this.gunaLabel39.Text = "0";
			this.gunaPanel64.Location = new Point(11, 99);
			this.gunaPanel64.Name = "gunaPanel64";
			this.gunaPanel64.Size = new Size(200, 15);
			this.gunaPanel64.TabIndex = 3;
			this.gunaPanel65.Location = new Point(11, 56);
			this.gunaPanel65.Name = "gunaPanel65";
			this.gunaPanel65.Size = new Size(200, 15);
			this.gunaPanel65.TabIndex = 3;
			this.gunaPanel66.Controls.Add(this.gunaLabel40);
			this.gunaPanel66.Location = new Point(11, 75);
			this.gunaPanel66.Name = "gunaPanel66";
			this.gunaPanel66.Size = new Size(200, 15);
			this.gunaPanel66.TabIndex = 3;
			this.gunaLabel40.AutoSize = true;
			this.gunaLabel40.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel40.ForeColor = Color.Silver;
			this.gunaLabel40.Location = new Point(-2, 3);
			this.gunaLabel40.Name = "gunaLabel40";
			this.gunaLabel40.Size = new Size(87, 13);
			this.gunaLabel40.TabIndex = 1;
			this.gunaLabel40.Text = "MaximumDelay";
			this.bunifuSlider10.BackColor = Color.Transparent;
			this.bunifuSlider10.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider10.BorderRadius = 0;
			this.bunifuSlider10.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider10.Location = new Point(11, 82);
			this.bunifuSlider10.MaximumValue = 500;
			this.bunifuSlider10.Name = "bunifuSlider10";
			this.bunifuSlider10.Size = new Size(200, 30);
			this.bunifuSlider10.TabIndex = 2;
			this.bunifuSlider10.Value = 20;
			this.gunaPanel67.Controls.Add(this.gunaLabel41);
			this.gunaPanel67.Location = new Point(11, 32);
			this.gunaPanel67.Name = "gunaPanel67";
			this.gunaPanel67.Size = new Size(200, 15);
			this.gunaPanel67.TabIndex = 3;
			this.gunaLabel41.AutoSize = true;
			this.gunaLabel41.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel41.ForeColor = Color.Silver;
			this.gunaLabel41.Location = new Point(-2, 3);
			this.gunaLabel41.Name = "gunaLabel41";
			this.gunaLabel41.Size = new Size(84, 13);
			this.gunaLabel41.TabIndex = 1;
			this.gunaLabel41.Text = "MinimumDelay";
			this.bunifuSlider11.BackColor = Color.Transparent;
			this.bunifuSlider11.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider11.BorderRadius = 0;
			this.bunifuSlider11.IndicatorColor = Color.FromArgb(80, 2, 100);
			this.bunifuSlider11.Location = new Point(11, 39);
			this.bunifuSlider11.MaximumValue = 500;
			this.bunifuSlider11.Name = "bunifuSlider11";
			this.bunifuSlider11.Size = new Size(200, 30);
			this.bunifuSlider11.TabIndex = 2;
			this.bunifuSlider11.Value = 0;
			this.gunaLabel42.AutoSize = true;
			this.gunaLabel42.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel42.ForeColor = Color.Silver;
			this.gunaLabel42.Location = new Point(8, 7);
			this.gunaLabel42.Name = "gunaLabel42";
			this.gunaLabel42.Size = new Size(47, 17);
			this.gunaLabel42.TabIndex = 1;
			this.gunaLabel42.Text = "W-Tap";
			this.gunaPanel68.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel68.Dock = DockStyle.Left;
			this.gunaPanel68.Location = new Point(0, 2);
			this.gunaPanel68.Name = "gunaPanel68";
			this.gunaPanel68.Size = new Size(2, 184);
			this.gunaPanel68.TabIndex = 0;
			this.gunaPanel69.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel69.Dock = DockStyle.Bottom;
			this.gunaPanel69.Location = new Point(0, 186);
			this.gunaPanel69.Name = "gunaPanel69";
			this.gunaPanel69.Size = new Size(246, 2);
			this.gunaPanel69.TabIndex = 0;
			this.gunaPanel70.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel70.Dock = DockStyle.Top;
			this.gunaPanel70.Location = new Point(0, 0);
			this.gunaPanel70.Name = "gunaPanel70";
			this.gunaPanel70.Size = new Size(246, 2);
			this.gunaPanel70.TabIndex = 0;
			this.gunaPanel71.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel71.Dock = DockStyle.Right;
			this.gunaPanel71.Location = new Point(246, 0);
			this.gunaPanel71.Name = "gunaPanel71";
			this.gunaPanel71.Size = new Size(2, 188);
			this.gunaPanel71.TabIndex = 0;
			this.tabPage3.BackColor = Color.FromArgb(15, 15, 15);
			this.tabPage3.Controls.Add(this.gunaPanel98);
			this.tabPage3.Controls.Add(this.gunaPanel125);
			this.tabPage3.Controls.Add(this.gunaPanel136);
			this.tabPage3.Controls.Add(this.gunaPanel126);
			this.tabPage3.Controls.Add(this.gunaPanel119);
			this.tabPage3.Controls.Add(this.gunaPanel113);
			this.tabPage3.Controls.Add(this.gunaPanel96);
			this.tabPage3.Location = new Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new Padding(3);
			this.tabPage3.Size = new Size(691, 508);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "tabPage3";
			this.gunaPanel98.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel98.Controls.Add(this.gunaLabel57);
			this.gunaPanel98.Controls.Add(this.gunaLabel56);
			this.gunaPanel98.Controls.Add(this.gunaShadowPanel11);
			this.gunaPanel98.Controls.Add(this.gunaShadowPanel10);
			this.gunaPanel98.Controls.Add(this.gunaLabel51);
			this.gunaPanel98.Controls.Add(this.gunaPanel99);
			this.gunaPanel98.Controls.Add(this.gunaPanel112);
			this.gunaPanel98.Controls.Add(this.bunifuSlider14);
			this.gunaPanel98.Controls.Add(this.gunaLabel53);
			this.gunaPanel98.Controls.Add(this.gunaPanel104);
			this.gunaPanel98.Controls.Add(this.gunaPanel105);
			this.gunaPanel98.Controls.Add(this.gunaPanel110);
			this.gunaPanel98.Controls.Add(this.gunaPanel111);
			this.gunaPanel98.Location = new Point(280, 2);
			this.gunaPanel98.Name = "gunaPanel98";
			this.gunaPanel98.Size = new Size(248, 159);
			this.gunaPanel98.TabIndex = 2;
			this.gunaLabel57.AutoSize = true;
			this.gunaLabel57.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel57.ForeColor = Color.FromArgb(15, 15, 15);
			this.gunaLabel57.Location = new Point(38, 103);
			this.gunaLabel57.Name = "gunaLabel57";
			this.gunaLabel57.Size = new Size(77, 13);
			this.gunaLabel57.TabIndex = 8;
			this.gunaLabel57.Text = "Custom Color";
			this.gunaLabel56.AutoSize = true;
			this.gunaLabel56.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel56.ForeColor = Color.FromArgb(15, 15, 15);
			this.gunaLabel56.Location = new Point(38, 77);
			this.gunaLabel56.Name = "gunaLabel56";
			this.gunaLabel56.Size = new Size(51, 13);
			this.gunaLabel56.TabIndex = 8;
			this.gunaLabel56.Text = "Rainbow";
			this.gunaShadowPanel11.BackColor = Color.Transparent;
			this.gunaShadowPanel11.BaseColor = Color.FromArgb(15, 15, 15);
			this.gunaShadowPanel11.Location = new Point(11, 98);
			this.gunaShadowPanel11.Name = "gunaShadowPanel11";
			this.gunaShadowPanel11.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel11.ShadowShift = 2;
			this.gunaShadowPanel11.Size = new Size(21, 18);
			this.gunaShadowPanel11.TabIndex = 9;
			this.gunaShadowPanel10.BackColor = Color.Transparent;
			this.gunaShadowPanel10.BaseColor = Color.FromArgb(15, 15, 15);
			this.gunaShadowPanel10.Location = new Point(11, 72);
			this.gunaShadowPanel10.Name = "gunaShadowPanel10";
			this.gunaShadowPanel10.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel10.ShadowShift = 2;
			this.gunaShadowPanel10.Size = new Size(21, 18);
			this.gunaShadowPanel10.TabIndex = 9;
			this.gunaLabel51.AutoSize = true;
			this.gunaLabel51.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel51.ForeColor = Color.FromArgb(15, 15, 15);
			this.gunaLabel51.Location = new Point(221, 38);
			this.gunaLabel51.Name = "gunaLabel51";
			this.gunaLabel51.Size = new Size(13, 13);
			this.gunaLabel51.TabIndex = 4;
			this.gunaLabel51.Text = "0";
			this.gunaPanel99.Location = new Point(11, 51);
			this.gunaPanel99.Name = "gunaPanel99";
			this.gunaPanel99.Size = new Size(200, 15);
			this.gunaPanel99.TabIndex = 6;
			this.gunaPanel112.Controls.Add(this.gunaLabel54);
			this.gunaPanel112.Location = new Point(11, 27);
			this.gunaPanel112.Name = "gunaPanel112";
			this.gunaPanel112.Size = new Size(200, 15);
			this.gunaPanel112.TabIndex = 7;
			this.gunaLabel54.AutoSize = true;
			this.gunaLabel54.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel54.ForeColor = Color.FromArgb(15, 15, 15);
			this.gunaLabel54.Location = new Point(-2, 3);
			this.gunaLabel54.Name = "gunaLabel54";
			this.gunaLabel54.Size = new Size(83, 13);
			this.gunaLabel54.TabIndex = 1;
			this.gunaLabel54.Text = "Rainbow Delay";
			this.bunifuSlider14.BackColor = Color.Transparent;
			this.bunifuSlider14.BackgroudColor = Color.FromArgb(20, 20, 20);
			this.bunifuSlider14.BorderRadius = 0;
			this.bunifuSlider14.Enabled = false;
			this.bunifuSlider14.IndicatorColor = Color.FromArgb(15, 15, 15);
			this.bunifuSlider14.Location = new Point(11, 34);
			this.bunifuSlider14.MaximumValue = 25;
			this.bunifuSlider14.Name = "bunifuSlider14";
			this.bunifuSlider14.Size = new Size(200, 30);
			this.bunifuSlider14.TabIndex = 5;
			this.bunifuSlider14.Value = 0;
			this.gunaLabel53.AutoSize = true;
			this.gunaLabel53.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel53.ForeColor = Color.FromArgb(15, 15, 15);
			this.gunaLabel53.Location = new Point(8, 7);
			this.gunaLabel53.Name = "gunaLabel53";
			this.gunaLabel53.Size = new Size(40, 17);
			this.gunaLabel53.TabIndex = 1;
			this.gunaLabel53.Text = "Color";
			this.gunaLabel53.Click += this.gunaLabel55_Click;
			this.gunaPanel104.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel104.Dock = DockStyle.Left;
			this.gunaPanel104.Location = new Point(0, 2);
			this.gunaPanel104.Name = "gunaPanel104";
			this.gunaPanel104.Size = new Size(2, 155);
			this.gunaPanel104.TabIndex = 0;
			this.gunaPanel105.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel105.Dock = DockStyle.Bottom;
			this.gunaPanel105.Location = new Point(0, 157);
			this.gunaPanel105.Name = "gunaPanel105";
			this.gunaPanel105.Size = new Size(246, 2);
			this.gunaPanel105.TabIndex = 0;
			this.gunaPanel110.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel110.Dock = DockStyle.Top;
			this.gunaPanel110.Location = new Point(0, 0);
			this.gunaPanel110.Name = "gunaPanel110";
			this.gunaPanel110.Size = new Size(246, 2);
			this.gunaPanel110.TabIndex = 0;
			this.gunaPanel111.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel111.Dock = DockStyle.Right;
			this.gunaPanel111.Location = new Point(246, 0);
			this.gunaPanel111.Name = "gunaPanel111";
			this.gunaPanel111.Size = new Size(2, 159);
			this.gunaPanel111.TabIndex = 0;
			this.gunaPanel125.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel125.Controls.Add(this.gunaLabel64);
			this.gunaPanel125.Controls.Add(this.gunaLabel62);
			this.gunaPanel125.Controls.Add(this.gunaShadowPanel14);
			this.gunaPanel125.Controls.Add(this.gunaShadowPanel13);
			this.gunaPanel125.Controls.Add(this.gunaLabel63);
			this.gunaPanel125.Controls.Add(this.gunaPanel127);
			this.gunaPanel125.Controls.Add(this.gunaPanel128);
			this.gunaPanel125.Controls.Add(this.gunaPanel129);
			this.gunaPanel125.Controls.Add(this.gunaPanel130);
			this.gunaPanel125.Location = new Point(534, 4);
			this.gunaPanel125.Name = "gunaPanel125";
			this.gunaPanel125.Size = new Size(146, 364);
			this.gunaPanel125.TabIndex = 2;
			this.gunaLabel64.AutoSize = true;
			this.gunaLabel64.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel64.ForeColor = Color.Silver;
			this.gunaLabel64.Location = new Point(39, 61);
			this.gunaLabel64.Name = "gunaLabel64";
			this.gunaLabel64.Size = new Size(66, 13);
			this.gunaLabel64.TabIndex = 8;
			this.gunaLabel64.Text = "Clear String";
			this.gunaLabel64.Click += this.gunaLabel64_Click;
			this.gunaLabel62.AutoSize = true;
			this.gunaLabel62.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel62.ForeColor = Color.Silver;
			this.gunaLabel62.Location = new Point(39, 37);
			this.gunaLabel62.Name = "gunaLabel62";
			this.gunaLabel62.Size = new Size(66, 13);
			this.gunaLabel62.TabIndex = 8;
			this.gunaLabel62.Text = "Clear Cache";
			this.gunaLabel62.Click += this.gunaLabel62_Click;
			this.gunaShadowPanel14.BackColor = Color.Transparent;
			this.gunaShadowPanel14.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel14.Location = new Point(12, 56);
			this.gunaShadowPanel14.Name = "gunaShadowPanel14";
			this.gunaShadowPanel14.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel14.ShadowShift = 2;
			this.gunaShadowPanel14.Size = new Size(21, 18);
			this.gunaShadowPanel14.TabIndex = 9;
			this.gunaShadowPanel14.Click += this.gunaShadowPanel14_Click;
			this.gunaShadowPanel13.BackColor = Color.Transparent;
			this.gunaShadowPanel13.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel13.Location = new Point(12, 32);
			this.gunaShadowPanel13.Name = "gunaShadowPanel13";
			this.gunaShadowPanel13.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel13.ShadowShift = 2;
			this.gunaShadowPanel13.Size = new Size(21, 18);
			this.gunaShadowPanel13.TabIndex = 9;
			this.gunaShadowPanel13.Click += this.gunaShadowPanel13_Click;
			this.gunaLabel63.AutoSize = true;
			this.gunaLabel63.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel63.ForeColor = Color.Silver;
			this.gunaLabel63.Location = new Point(8, 7);
			this.gunaLabel63.Name = "gunaLabel63";
			this.gunaLabel63.Size = new Size(80, 17);
			this.gunaLabel63.TabIndex = 1;
			this.gunaLabel63.Text = "SelfDestruct";
			this.gunaLabel63.Click += this.gunaLabel55_Click;
			this.gunaPanel127.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel127.Dock = DockStyle.Left;
			this.gunaPanel127.Location = new Point(0, 2);
			this.gunaPanel127.Name = "gunaPanel127";
			this.gunaPanel127.Size = new Size(2, 360);
			this.gunaPanel127.TabIndex = 0;
			this.gunaPanel128.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel128.Dock = DockStyle.Bottom;
			this.gunaPanel128.Location = new Point(0, 362);
			this.gunaPanel128.Name = "gunaPanel128";
			this.gunaPanel128.Size = new Size(144, 2);
			this.gunaPanel128.TabIndex = 0;
			this.gunaPanel129.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel129.Dock = DockStyle.Top;
			this.gunaPanel129.Location = new Point(0, 0);
			this.gunaPanel129.Name = "gunaPanel129";
			this.gunaPanel129.Size = new Size(144, 2);
			this.gunaPanel129.TabIndex = 0;
			this.gunaPanel130.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel130.Dock = DockStyle.Right;
			this.gunaPanel130.Location = new Point(144, 0);
			this.gunaPanel130.Name = "gunaPanel130";
			this.gunaPanel130.Size = new Size(2, 364);
			this.gunaPanel130.TabIndex = 0;
			this.gunaPanel136.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel136.Controls.Add(this.gunaTextBox3);
			this.gunaPanel136.Controls.Add(this.gunaLabel67);
			this.gunaPanel136.Controls.Add(this.gunaAdvenceButton31);
			this.gunaPanel136.Controls.Add(this.gunaLabel69);
			this.gunaPanel136.Controls.Add(this.gunaPanel137);
			this.gunaPanel136.Controls.Add(this.gunaShadowPanel16);
			this.gunaPanel136.Controls.Add(this.gunaLabel68);
			this.gunaPanel136.Controls.Add(this.gunaPanel138);
			this.gunaPanel136.Controls.Add(this.gunaPanel139);
			this.gunaPanel136.Controls.Add(this.gunaPanel140);
			this.gunaPanel136.Controls.Add(this.gunaPanel141);
			this.gunaPanel136.Location = new Point(280, 332);
			this.gunaPanel136.Name = "gunaPanel136";
			this.gunaPanel136.Size = new Size(248, 159);
			this.gunaPanel136.TabIndex = 2;
			this.gunaTextBox3.BaseColor = Color.FromArgb(11, 11, 11);
			this.gunaTextBox3.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox3.Cursor = Cursors.IBeam;
			this.gunaTextBox3.FocusedBaseColor = Color.WhiteSmoke;
			this.gunaTextBox3.FocusedBorderColor = Color.FromArgb(100, 88, 255);
			this.gunaTextBox3.FocusedForeColor = SystemColors.ControlText;
			this.gunaTextBox3.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox3.ForeColor = Color.Silver;
			this.gunaTextBox3.Location = new Point(67, 118);
			this.gunaTextBox3.Name = "gunaTextBox3";
			this.gunaTextBox3.PasswordChar = '\0';
			this.gunaTextBox3.SelectedText = "";
			this.gunaTextBox3.Size = new Size(146, 30);
			this.gunaTextBox3.TabIndex = 6;
			this.gunaTextBox3.Text = "minecraft.landia@gmail.com";
			this.gunaTextBox3.TextAlign = HorizontalAlignment.Center;
			this.gunaLabel67.AutoSize = true;
			this.gunaLabel67.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel67.ForeColor = Color.Silver;
			this.gunaLabel67.Location = new Point(39, 37);
			this.gunaLabel67.Name = "gunaLabel67";
			this.gunaLabel67.Size = new Size(67, 13);
			this.gunaLabel67.TabIndex = 8;
			this.gunaLabel67.Text = "ALT and SFA";
			this.gunaLabel67.Click += this.gunaLabel67_Click;
			this.gunaAdvenceButton31.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton31.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton31.BackColor = Color.Transparent;
			this.gunaAdvenceButton31.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton31.BorderColor = Color.Black;
			this.gunaAdvenceButton31.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton31.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton31.CheckedForeColor = Color.White;
			this.gunaAdvenceButton31.CheckedImage = null;
			this.gunaAdvenceButton31.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton31.DialogResult = DialogResult.None;
			this.gunaAdvenceButton31.FocusedColor = Color.Empty;
			this.gunaAdvenceButton31.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton31.ForeColor = Color.Silver;
			this.gunaAdvenceButton31.Image = null;
			this.gunaAdvenceButton31.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton31.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton31.Location = new Point(19, 68);
			this.gunaAdvenceButton31.Name = "gunaAdvenceButton31";
			this.gunaAdvenceButton31.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton31.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton31.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton31.OnHoverImage = null;
			this.gunaAdvenceButton31.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton31.OnPressedColor = Color.Black;
			this.gunaAdvenceButton31.Radius = 2;
			this.gunaAdvenceButton31.Size = new Size(192, 37);
			this.gunaAdvenceButton31.TabIndex = 5;
			this.gunaAdvenceButton31.Text = "Generates";
			this.gunaAdvenceButton31.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton31.Click += this.gunaAdvenceButton26_Click;
			this.gunaLabel69.AutoSize = true;
			this.gunaLabel69.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel69.ForeColor = Color.Silver;
			this.gunaLabel69.Location = new Point(9, 129);
			this.gunaLabel69.Name = "gunaLabel69";
			this.gunaLabel69.Size = new Size(58, 17);
			this.gunaLabel69.TabIndex = 1;
			this.gunaLabel69.Text = "Account";
			this.gunaLabel69.Click += this.gunaLabel55_Click;
			this.gunaPanel137.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel137.Location = new Point(20, 57);
			this.gunaPanel137.Name = "gunaPanel137";
			this.gunaPanel137.Size = new Size(191, 2);
			this.gunaPanel137.TabIndex = 0;
			this.gunaShadowPanel16.BackColor = Color.Transparent;
			this.gunaShadowPanel16.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel16.Location = new Point(12, 32);
			this.gunaShadowPanel16.Name = "gunaShadowPanel16";
			this.gunaShadowPanel16.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel16.ShadowShift = 2;
			this.gunaShadowPanel16.Size = new Size(21, 18);
			this.gunaShadowPanel16.TabIndex = 9;
			this.gunaShadowPanel16.ClientSizeChanged += this.gunaShadowPanel16_ClientSizeChanged;
			this.gunaShadowPanel16.Click += this.gunaShadowPanel16_Click;
			this.gunaLabel68.AutoSize = true;
			this.gunaLabel68.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel68.ForeColor = Color.Silver;
			this.gunaLabel68.Location = new Point(8, 7);
			this.gunaLabel68.Name = "gunaLabel68";
			this.gunaLabel68.Size = new Size(123, 17);
			this.gunaLabel68.TabIndex = 1;
			this.gunaLabel68.Text = "Account Generator";
			this.gunaLabel68.Click += this.gunaLabel55_Click;
			this.gunaPanel138.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel138.Dock = DockStyle.Left;
			this.gunaPanel138.Location = new Point(0, 2);
			this.gunaPanel138.Name = "gunaPanel138";
			this.gunaPanel138.Size = new Size(2, 155);
			this.gunaPanel138.TabIndex = 0;
			this.gunaPanel139.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel139.Dock = DockStyle.Bottom;
			this.gunaPanel139.Location = new Point(0, 157);
			this.gunaPanel139.Name = "gunaPanel139";
			this.gunaPanel139.Size = new Size(246, 2);
			this.gunaPanel139.TabIndex = 0;
			this.gunaPanel140.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel140.Dock = DockStyle.Top;
			this.gunaPanel140.Location = new Point(0, 0);
			this.gunaPanel140.Name = "gunaPanel140";
			this.gunaPanel140.Size = new Size(246, 2);
			this.gunaPanel140.TabIndex = 0;
			this.gunaPanel141.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel141.Dock = DockStyle.Right;
			this.gunaPanel141.Location = new Point(246, 0);
			this.gunaPanel141.Name = "gunaPanel141";
			this.gunaPanel141.Size = new Size(2, 159);
			this.gunaPanel141.TabIndex = 0;
			this.gunaPanel126.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel126.Controls.Add(this.gunaAdvenceButton28);
			this.gunaPanel126.Controls.Add(this.gunaLabel65);
			this.gunaPanel126.Controls.Add(this.gunaAdvenceButton29);
			this.gunaPanel126.Controls.Add(this.gunaPanel131);
			this.gunaPanel126.Controls.Add(this.gunaShadowPanel15);
			this.gunaPanel126.Controls.Add(this.gunaLabel66);
			this.gunaPanel126.Controls.Add(this.gunaPanel132);
			this.gunaPanel126.Controls.Add(this.gunaPanel133);
			this.gunaPanel126.Controls.Add(this.gunaPanel134);
			this.gunaPanel126.Controls.Add(this.gunaPanel135);
			this.gunaPanel126.Location = new Point(22, 332);
			this.gunaPanel126.Name = "gunaPanel126";
			this.gunaPanel126.Size = new Size(248, 159);
			this.gunaPanel126.TabIndex = 2;
			this.gunaAdvenceButton28.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton28.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton28.BackColor = Color.Transparent;
			this.gunaAdvenceButton28.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton28.BorderColor = Color.Black;
			this.gunaAdvenceButton28.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton28.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton28.CheckedForeColor = Color.White;
			this.gunaAdvenceButton28.CheckedImage = null;
			this.gunaAdvenceButton28.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton28.DialogResult = DialogResult.None;
			this.gunaAdvenceButton28.FocusedColor = Color.Empty;
			this.gunaAdvenceButton28.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton28.ForeColor = Color.Silver;
			this.gunaAdvenceButton28.Image = null;
			this.gunaAdvenceButton28.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton28.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton28.Location = new Point(20, 111);
			this.gunaAdvenceButton28.Name = "gunaAdvenceButton28";
			this.gunaAdvenceButton28.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton28.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton28.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton28.OnHoverImage = null;
			this.gunaAdvenceButton28.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton28.OnPressedColor = Color.Black;
			this.gunaAdvenceButton28.Radius = 2;
			this.gunaAdvenceButton28.Size = new Size(192, 37);
			this.gunaAdvenceButton28.TabIndex = 5;
			this.gunaAdvenceButton28.Text = "<....>";
			this.gunaAdvenceButton28.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton28.Click += this.gunaAdvenceButton26_Click;
			this.gunaLabel65.AutoSize = true;
			this.gunaLabel65.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel65.ForeColor = Color.Silver;
			this.gunaLabel65.Location = new Point(39, 37);
			this.gunaLabel65.Name = "gunaLabel65";
			this.gunaLabel65.Size = new Size(171, 13);
			this.gunaLabel65.TabIndex = 8;
			this.gunaLabel65.Text = "always remember when entering";
			this.gunaLabel65.Click += this.gunaLabel65_Click;
			this.gunaAdvenceButton29.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton29.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton29.BackColor = Color.Transparent;
			this.gunaAdvenceButton29.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton29.BorderColor = Color.Black;
			this.gunaAdvenceButton29.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton29.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton29.CheckedForeColor = Color.White;
			this.gunaAdvenceButton29.CheckedImage = null;
			this.gunaAdvenceButton29.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton29.DialogResult = DialogResult.None;
			this.gunaAdvenceButton29.FocusedColor = Color.Empty;
			this.gunaAdvenceButton29.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton29.ForeColor = Color.Silver;
			this.gunaAdvenceButton29.Image = null;
			this.gunaAdvenceButton29.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton29.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton29.Location = new Point(19, 68);
			this.gunaAdvenceButton29.Name = "gunaAdvenceButton29";
			this.gunaAdvenceButton29.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton29.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton29.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton29.OnHoverImage = null;
			this.gunaAdvenceButton29.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton29.OnPressedColor = Color.Black;
			this.gunaAdvenceButton29.Radius = 2;
			this.gunaAdvenceButton29.Size = new Size(192, 37);
			this.gunaAdvenceButton29.TabIndex = 5;
			this.gunaAdvenceButton29.Text = "Check ";
			this.gunaAdvenceButton29.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton29.Click += this.gunaAdvenceButton26_Click;
			this.gunaPanel131.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel131.Location = new Point(20, 57);
			this.gunaPanel131.Name = "gunaPanel131";
			this.gunaPanel131.Size = new Size(191, 2);
			this.gunaPanel131.TabIndex = 0;
			this.gunaShadowPanel15.BackColor = Color.Transparent;
			this.gunaShadowPanel15.BaseColor = Color.FromArgb(15, 15, 15);
			this.gunaShadowPanel15.Location = new Point(12, 32);
			this.gunaShadowPanel15.Name = "gunaShadowPanel15";
			this.gunaShadowPanel15.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel15.ShadowShift = 2;
			this.gunaShadowPanel15.Size = new Size(21, 18);
			this.gunaShadowPanel15.TabIndex = 9;
			this.gunaShadowPanel15.Click += this.gunaShadowPanel15_Click;
			this.gunaLabel66.AutoSize = true;
			this.gunaLabel66.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel66.ForeColor = Color.Silver;
			this.gunaLabel66.Location = new Point(8, 7);
			this.gunaLabel66.Name = "gunaLabel66";
			this.gunaLabel66.Size = new Size(97, 17);
			this.gunaLabel66.TabIndex = 1;
			this.gunaLabel66.Text = "Check updates";
			this.gunaLabel66.Click += this.gunaLabel55_Click;
			this.gunaPanel132.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel132.Dock = DockStyle.Left;
			this.gunaPanel132.Location = new Point(0, 2);
			this.gunaPanel132.Name = "gunaPanel132";
			this.gunaPanel132.Size = new Size(2, 155);
			this.gunaPanel132.TabIndex = 0;
			this.gunaPanel133.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel133.Dock = DockStyle.Bottom;
			this.gunaPanel133.Location = new Point(0, 157);
			this.gunaPanel133.Name = "gunaPanel133";
			this.gunaPanel133.Size = new Size(246, 2);
			this.gunaPanel133.TabIndex = 0;
			this.gunaPanel134.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel134.Dock = DockStyle.Top;
			this.gunaPanel134.Location = new Point(0, 0);
			this.gunaPanel134.Name = "gunaPanel134";
			this.gunaPanel134.Size = new Size(246, 2);
			this.gunaPanel134.TabIndex = 0;
			this.gunaPanel135.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel135.Dock = DockStyle.Right;
			this.gunaPanel135.Location = new Point(246, 0);
			this.gunaPanel135.Name = "gunaPanel135";
			this.gunaPanel135.Size = new Size(2, 159);
			this.gunaPanel135.TabIndex = 0;
			this.gunaPanel119.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel119.Controls.Add(this.gunaAdvenceButton27);
			this.gunaPanel119.Controls.Add(this.gunaLabel60);
			this.gunaPanel119.Controls.Add(this.gunaAdvenceButton26);
			this.gunaPanel119.Controls.Add(this.gunaPanel120);
			this.gunaPanel119.Controls.Add(this.gunaShadowPanel12);
			this.gunaPanel119.Controls.Add(this.gunaLabel61);
			this.gunaPanel119.Controls.Add(this.gunaPanel121);
			this.gunaPanel119.Controls.Add(this.gunaPanel122);
			this.gunaPanel119.Controls.Add(this.gunaPanel123);
			this.gunaPanel119.Controls.Add(this.gunaPanel124);
			this.gunaPanel119.Location = new Point(280, 167);
			this.gunaPanel119.Name = "gunaPanel119";
			this.gunaPanel119.Size = new Size(248, 159);
			this.gunaPanel119.TabIndex = 2;
			this.gunaAdvenceButton27.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton27.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton27.BackColor = Color.Transparent;
			this.gunaAdvenceButton27.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton27.BorderColor = Color.Black;
			this.gunaAdvenceButton27.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton27.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton27.CheckedForeColor = Color.White;
			this.gunaAdvenceButton27.CheckedImage = null;
			this.gunaAdvenceButton27.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton27.DialogResult = DialogResult.None;
			this.gunaAdvenceButton27.FocusedColor = Color.Empty;
			this.gunaAdvenceButton27.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton27.ForeColor = Color.Silver;
			this.gunaAdvenceButton27.Image = null;
			this.gunaAdvenceButton27.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton27.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton27.Location = new Point(20, 111);
			this.gunaAdvenceButton27.Name = "gunaAdvenceButton27";
			this.gunaAdvenceButton27.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton27.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton27.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton27.OnHoverImage = null;
			this.gunaAdvenceButton27.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton27.OnPressedColor = Color.Black;
			this.gunaAdvenceButton27.Radius = 2;
			this.gunaAdvenceButton27.Size = new Size(192, 37);
			this.gunaAdvenceButton27.TabIndex = 5;
			this.gunaAdvenceButton27.Text = "Close";
			this.gunaAdvenceButton27.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton27.Click += this.gunaAdvenceButton26_Click;
			this.gunaLabel60.AutoSize = true;
			this.gunaLabel60.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel60.ForeColor = Color.Silver;
			this.gunaLabel60.Location = new Point(39, 37);
			this.gunaLabel60.Name = "gunaLabel60";
			this.gunaLabel60.Size = new Size(79, 13);
			this.gunaLabel60.TabIndex = 8;
			this.gunaLabel60.Text = "Using Options";
			this.gunaLabel60.Click += this.gunaLabel60_Click;
			this.gunaAdvenceButton26.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton26.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton26.BackColor = Color.Transparent;
			this.gunaAdvenceButton26.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton26.BorderColor = Color.Black;
			this.gunaAdvenceButton26.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton26.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton26.CheckedForeColor = Color.White;
			this.gunaAdvenceButton26.CheckedImage = null;
			this.gunaAdvenceButton26.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton26.DialogResult = DialogResult.None;
			this.gunaAdvenceButton26.FocusedColor = Color.Empty;
			this.gunaAdvenceButton26.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton26.ForeColor = Color.Silver;
			this.gunaAdvenceButton26.Image = null;
			this.gunaAdvenceButton26.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton26.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton26.Location = new Point(19, 68);
			this.gunaAdvenceButton26.Name = "gunaAdvenceButton26";
			this.gunaAdvenceButton26.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton26.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton26.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton26.OnHoverImage = null;
			this.gunaAdvenceButton26.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton26.OnPressedColor = Color.Black;
			this.gunaAdvenceButton26.Radius = 2;
			this.gunaAdvenceButton26.Size = new Size(192, 37);
			this.gunaAdvenceButton26.TabIndex = 5;
			this.gunaAdvenceButton26.Text = "Destruct";
			this.gunaAdvenceButton26.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton26.Click += this.gunaAdvenceButton26_Click;
			this.gunaPanel120.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel120.Location = new Point(20, 57);
			this.gunaPanel120.Name = "gunaPanel120";
			this.gunaPanel120.Size = new Size(191, 2);
			this.gunaPanel120.TabIndex = 0;
			this.gunaShadowPanel12.BackColor = Color.Transparent;
			this.gunaShadowPanel12.BaseColor = Color.FromArgb(80, 2, 100);
			this.gunaShadowPanel12.Location = new Point(12, 32);
			this.gunaShadowPanel12.Name = "gunaShadowPanel12";
			this.gunaShadowPanel12.ShadowColor = Color.FromArgb(20, 20, 20);
			this.gunaShadowPanel12.ShadowShift = 2;
			this.gunaShadowPanel12.Size = new Size(21, 18);
			this.gunaShadowPanel12.TabIndex = 9;
			this.gunaShadowPanel12.Click += this.gunaShadowPanel12_Click;
			this.gunaLabel61.AutoSize = true;
			this.gunaLabel61.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel61.ForeColor = Color.Silver;
			this.gunaLabel61.Location = new Point(8, 7);
			this.gunaLabel61.Name = "gunaLabel61";
			this.gunaLabel61.Size = new Size(80, 17);
			this.gunaLabel61.TabIndex = 1;
			this.gunaLabel61.Text = "SelfDestruct";
			this.gunaLabel61.Click += this.gunaLabel55_Click;
			this.gunaPanel121.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel121.Dock = DockStyle.Left;
			this.gunaPanel121.Location = new Point(0, 2);
			this.gunaPanel121.Name = "gunaPanel121";
			this.gunaPanel121.Size = new Size(2, 155);
			this.gunaPanel121.TabIndex = 0;
			this.gunaPanel122.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel122.Dock = DockStyle.Bottom;
			this.gunaPanel122.Location = new Point(0, 157);
			this.gunaPanel122.Name = "gunaPanel122";
			this.gunaPanel122.Size = new Size(246, 2);
			this.gunaPanel122.TabIndex = 0;
			this.gunaPanel123.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel123.Dock = DockStyle.Top;
			this.gunaPanel123.Location = new Point(0, 0);
			this.gunaPanel123.Name = "gunaPanel123";
			this.gunaPanel123.Size = new Size(246, 2);
			this.gunaPanel123.TabIndex = 0;
			this.gunaPanel124.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel124.Dock = DockStyle.Right;
			this.gunaPanel124.Location = new Point(246, 0);
			this.gunaPanel124.Name = "gunaPanel124";
			this.gunaPanel124.Size = new Size(2, 159);
			this.gunaPanel124.TabIndex = 0;
			this.gunaPanel113.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel113.Controls.Add(this.gunaTextBox2);
			this.gunaPanel113.Controls.Add(this.gunaAdvenceButton25);
			this.gunaPanel113.Controls.Add(this.gunaPanel114);
			this.gunaPanel113.Controls.Add(this.gunaLabel58);
			this.gunaPanel113.Controls.Add(this.gunaLabel59);
			this.gunaPanel113.Controls.Add(this.gunaPanel115);
			this.gunaPanel113.Controls.Add(this.gunaPanel116);
			this.gunaPanel113.Controls.Add(this.gunaPanel117);
			this.gunaPanel113.Controls.Add(this.gunaPanel118);
			this.gunaPanel113.Location = new Point(22, 167);
			this.gunaPanel113.Name = "gunaPanel113";
			this.gunaPanel113.Size = new Size(248, 159);
			this.gunaPanel113.TabIndex = 2;
			this.gunaTextBox2.BaseColor = Color.FromArgb(11, 11, 11);
			this.gunaTextBox2.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox2.Cursor = Cursors.IBeam;
			this.gunaTextBox2.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox2.FocusedBorderColor = Color.FromArgb(12, 12, 12);
			this.gunaTextBox2.FocusedForeColor = Color.Silver;
			this.gunaTextBox2.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox2.ForeColor = Color.Silver;
			this.gunaTextBox2.Location = new Point(68, 51);
			this.gunaTextBox2.Name = "gunaTextBox2";
			this.gunaTextBox2.PasswordChar = '\0';
			this.gunaTextBox2.SelectedText = "";
			this.gunaTextBox2.Size = new Size(146, 30);
			this.gunaTextBox2.TabIndex = 6;
			this.gunaTextBox2.Text = "000.0.0.0";
			this.gunaTextBox2.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton25.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton25.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton25.BackColor = Color.Transparent;
			this.gunaAdvenceButton25.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton25.BorderColor = Color.Black;
			this.gunaAdvenceButton25.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton25.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton25.CheckedForeColor = Color.White;
			this.gunaAdvenceButton25.CheckedImage = null;
			this.gunaAdvenceButton25.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton25.DialogResult = DialogResult.None;
			this.gunaAdvenceButton25.FocusedColor = Color.Empty;
			this.gunaAdvenceButton25.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton25.ForeColor = Color.Silver;
			this.gunaAdvenceButton25.Image = null;
			this.gunaAdvenceButton25.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton25.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton25.Location = new Point(22, 98);
			this.gunaAdvenceButton25.Name = "gunaAdvenceButton25";
			this.gunaAdvenceButton25.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton25.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton25.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton25.OnHoverImage = null;
			this.gunaAdvenceButton25.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton25.OnPressedColor = Color.Black;
			this.gunaAdvenceButton25.Radius = 2;
			this.gunaAdvenceButton25.Size = new Size(192, 37);
			this.gunaAdvenceButton25.TabIndex = 5;
			this.gunaAdvenceButton25.Text = "Resolve";
			this.gunaAdvenceButton25.TextAlign = HorizontalAlignment.Center;
			this.gunaPanel114.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel114.Location = new Point(23, 87);
			this.gunaPanel114.Name = "gunaPanel114";
			this.gunaPanel114.Size = new Size(191, 2);
			this.gunaPanel114.TabIndex = 0;
			this.gunaLabel58.AutoSize = true;
			this.gunaLabel58.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel58.ForeColor = Color.Silver;
			this.gunaLabel58.Location = new Point(20, 64);
			this.gunaLabel58.Name = "gunaLabel58";
			this.gunaLabel58.Size = new Size(30, 17);
			this.gunaLabel58.TabIndex = 1;
			this.gunaLabel58.Text = "IPs ";
			this.gunaLabel58.Click += this.gunaLabel55_Click;
			this.gunaLabel59.AutoSize = true;
			this.gunaLabel59.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel59.ForeColor = Color.Silver;
			this.gunaLabel59.Location = new Point(8, 7);
			this.gunaLabel59.Name = "gunaLabel59";
			this.gunaLabel59.Size = new Size(98, 17);
			this.gunaLabel59.TabIndex = 1;
			this.gunaLabel59.Text = "DDOS Resolver";
			this.gunaLabel59.Click += this.gunaLabel55_Click;
			this.gunaPanel115.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel115.Dock = DockStyle.Left;
			this.gunaPanel115.Location = new Point(0, 2);
			this.gunaPanel115.Name = "gunaPanel115";
			this.gunaPanel115.Size = new Size(2, 155);
			this.gunaPanel115.TabIndex = 0;
			this.gunaPanel116.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel116.Dock = DockStyle.Bottom;
			this.gunaPanel116.Location = new Point(0, 157);
			this.gunaPanel116.Name = "gunaPanel116";
			this.gunaPanel116.Size = new Size(246, 2);
			this.gunaPanel116.TabIndex = 0;
			this.gunaPanel117.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel117.Dock = DockStyle.Top;
			this.gunaPanel117.Location = new Point(0, 0);
			this.gunaPanel117.Name = "gunaPanel117";
			this.gunaPanel117.Size = new Size(246, 2);
			this.gunaPanel117.TabIndex = 0;
			this.gunaPanel118.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel118.Dock = DockStyle.Right;
			this.gunaPanel118.Location = new Point(246, 0);
			this.gunaPanel118.Name = "gunaPanel118";
			this.gunaPanel118.Size = new Size(2, 159);
			this.gunaPanel118.TabIndex = 0;
			this.gunaPanel96.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel96.Controls.Add(this.gunaTextBox1);
			this.gunaPanel96.Controls.Add(this.gunaAdvenceButton24);
			this.gunaPanel96.Controls.Add(this.gunaPanel97);
			this.gunaPanel96.Controls.Add(this.gunaLabel50);
			this.gunaPanel96.Controls.Add(this.gunaLabel55);
			this.gunaPanel96.Controls.Add(this.gunaPanel106);
			this.gunaPanel96.Controls.Add(this.gunaPanel107);
			this.gunaPanel96.Controls.Add(this.gunaPanel108);
			this.gunaPanel96.Controls.Add(this.gunaPanel109);
			this.gunaPanel96.Location = new Point(22, 2);
			this.gunaPanel96.Name = "gunaPanel96";
			this.gunaPanel96.Size = new Size(248, 159);
			this.gunaPanel96.TabIndex = 2;
			this.gunaTextBox1.BaseColor = Color.FromArgb(11, 11, 11);
			this.gunaTextBox1.BorderColor = Color.FromArgb(8, 8, 8);
			this.gunaTextBox1.Cursor = Cursors.IBeam;
			this.gunaTextBox1.FocusedBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaTextBox1.FocusedBorderColor = Color.FromArgb(12, 12, 12);
			this.gunaTextBox1.FocusedForeColor = Color.Silver;
			this.gunaTextBox1.Font = new Font("Segoe UI", 9f);
			this.gunaTextBox1.ForeColor = Color.Silver;
			this.gunaTextBox1.Location = new Point(68, 51);
			this.gunaTextBox1.Name = "gunaTextBox1";
			this.gunaTextBox1.PasswordChar = '\0';
			this.gunaTextBox1.SelectedText = "";
			this.gunaTextBox1.Size = new Size(146, 30);
			this.gunaTextBox1.TabIndex = 6;
			this.gunaTextBox1.Text = "000.0.0.0";
			this.gunaTextBox1.TextAlign = HorizontalAlignment.Center;
			this.gunaAdvenceButton24.AnimationHoverSpeed = 0.07f;
			this.gunaAdvenceButton24.AnimationSpeed = 0.03f;
			this.gunaAdvenceButton24.BackColor = Color.Transparent;
			this.gunaAdvenceButton24.BaseColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton24.BorderColor = Color.Black;
			this.gunaAdvenceButton24.CheckedBaseColor = Color.Gray;
			this.gunaAdvenceButton24.CheckedBorderColor = Color.Black;
			this.gunaAdvenceButton24.CheckedForeColor = Color.White;
			this.gunaAdvenceButton24.CheckedImage = null;
			this.gunaAdvenceButton24.CheckedLineColor = Color.DimGray;
			this.gunaAdvenceButton24.DialogResult = DialogResult.None;
			this.gunaAdvenceButton24.FocusedColor = Color.Empty;
			this.gunaAdvenceButton24.Font = new Font("Segoe UI", 9f);
			this.gunaAdvenceButton24.ForeColor = Color.Silver;
			this.gunaAdvenceButton24.Image = null;
			this.gunaAdvenceButton24.ImageSize = new Size(20, 20);
			this.gunaAdvenceButton24.LineColor = Color.FromArgb(8, 8, 8);
			this.gunaAdvenceButton24.Location = new Point(22, 98);
			this.gunaAdvenceButton24.Name = "gunaAdvenceButton24";
			this.gunaAdvenceButton24.OnHoverBaseColor = Color.FromArgb(10, 10, 10);
			this.gunaAdvenceButton24.OnHoverBorderColor = Color.Black;
			this.gunaAdvenceButton24.OnHoverForeColor = Color.Silver;
			this.gunaAdvenceButton24.OnHoverImage = null;
			this.gunaAdvenceButton24.OnHoverLineColor = Color.FromArgb(66, 58, 170);
			this.gunaAdvenceButton24.OnPressedColor = Color.Black;
			this.gunaAdvenceButton24.Radius = 2;
			this.gunaAdvenceButton24.Size = new Size(192, 37);
			this.gunaAdvenceButton24.TabIndex = 5;
			this.gunaAdvenceButton24.Text = "Resolve";
			this.gunaAdvenceButton24.TextAlign = HorizontalAlignment.Center;
			this.gunaPanel97.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel97.Location = new Point(23, 87);
			this.gunaPanel97.Name = "gunaPanel97";
			this.gunaPanel97.Size = new Size(191, 2);
			this.gunaPanel97.TabIndex = 0;
			this.gunaLabel50.AutoSize = true;
			this.gunaLabel50.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel50.ForeColor = Color.Silver;
			this.gunaLabel50.Location = new Point(20, 64);
			this.gunaLabel50.Name = "gunaLabel50";
			this.gunaLabel50.Size = new Size(26, 17);
			this.gunaLabel50.TabIndex = 1;
			this.gunaLabel50.Text = "IPs";
			this.gunaLabel50.Click += this.gunaLabel55_Click;
			this.gunaLabel55.AutoSize = true;
			this.gunaLabel55.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel55.ForeColor = Color.Silver;
			this.gunaLabel55.Location = new Point(8, 7);
			this.gunaLabel55.Name = "gunaLabel55";
			this.gunaLabel55.Size = new Size(116, 17);
			this.gunaLabel55.TabIndex = 1;
			this.gunaLabel55.Text = "AnyDesk Resolver";
			this.gunaLabel55.Click += this.gunaLabel55_Click;
			this.gunaPanel106.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel106.Dock = DockStyle.Left;
			this.gunaPanel106.Location = new Point(0, 2);
			this.gunaPanel106.Name = "gunaPanel106";
			this.gunaPanel106.Size = new Size(2, 155);
			this.gunaPanel106.TabIndex = 0;
			this.gunaPanel107.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel107.Dock = DockStyle.Bottom;
			this.gunaPanel107.Location = new Point(0, 157);
			this.gunaPanel107.Name = "gunaPanel107";
			this.gunaPanel107.Size = new Size(246, 2);
			this.gunaPanel107.TabIndex = 0;
			this.gunaPanel108.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel108.Dock = DockStyle.Top;
			this.gunaPanel108.Location = new Point(0, 0);
			this.gunaPanel108.Name = "gunaPanel108";
			this.gunaPanel108.Size = new Size(246, 2);
			this.gunaPanel108.TabIndex = 0;
			this.gunaPanel109.BackColor = Color.FromArgb(20, 20, 20);
			this.gunaPanel109.Dock = DockStyle.Right;
			this.gunaPanel109.Location = new Point(246, 0);
			this.gunaPanel109.Name = "gunaPanel109";
			this.gunaPanel109.Size = new Size(2, 159);
			this.gunaPanel109.TabIndex = 0;
			this.gunaPanel5.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel5.Location = new Point(91, 10);
			this.gunaPanel5.Name = "gunaPanel5";
			this.gunaPanel5.Size = new Size(704, 5);
			this.gunaPanel5.TabIndex = 0;
			this.gunaPanel2.BackColor = Color.FromArgb(12, 12, 12);
			this.gunaPanel2.Location = new Point(87, 10);
			this.gunaPanel2.Name = "gunaPanel2";
			this.gunaPanel2.Size = new Size(5, 546);
			this.gunaPanel2.TabIndex = 0;
			this.gunaPanel1.BackColor = Color.FromArgb(10, 10, 10);
			this.gunaPanel1.Controls.Add(this.gunaImageCheckBox3);
			this.gunaPanel1.Controls.Add(this.gunaImageCheckBox2);
			this.gunaPanel1.Controls.Add(this.gunaImageCheckBox1);
			this.gunaPanel1.Controls.Add(this.gunaLabel81);
			this.gunaPanel1.Controls.Add(this.gunaLabel80);
			this.gunaPanel1.Controls.Add(this.gunaLabel79);
			this.gunaPanel1.Controls.Add(this.gunaLabel78);
			this.gunaPanel1.Controls.Add(this.gunaLabel77);
			this.gunaPanel1.Controls.Add(this.gunaLabel76);
			this.gunaPanel1.Controls.Add(this.gunaLabel75);
			this.gunaPanel1.Controls.Add(this.gunaLabel86);
			this.gunaPanel1.Controls.Add(this.gunaLabel85);
			this.gunaPanel1.Controls.Add(this.gunaLabel83);
			this.gunaPanel1.Controls.Add(this.gunaLabel84);
			this.gunaPanel1.Controls.Add(this.gunaLabel82);
			this.gunaPanel1.Controls.Add(this.gunaLabel74);
			this.gunaPanel1.Controls.Add(this.gunaLabel73);
			this.gunaPanel1.Controls.Add(this.gunaLabel33);
			this.gunaPanel1.Location = new Point(11, 10);
			this.gunaPanel1.Name = "gunaPanel1";
			this.gunaPanel1.Size = new Size(78, 546);
			this.gunaPanel1.TabIndex = 0;
			this.gunaPanel1.Paint += this.gunaPanel1_Paint;
			this.gunaImageCheckBox3.ImageCheckedOff = Resources.more_desativado;
			this.gunaImageCheckBox3.ImageCheckedOn = Resources.more_ativado;
			this.gunaImageCheckBox3.ImageSize = new Size(20, 20);
			this.gunaImageCheckBox3.Location = new Point(14, 253);
			this.gunaImageCheckBox3.Name = "gunaImageCheckBox3";
			this.gunaImageCheckBox3.Size = new Size(51, 38);
			this.gunaImageCheckBox3.TabIndex = 1;
			this.gunaImageCheckBox3.CheckedChanged += this.gunaImageCheckBox3_CheckedChanged;
			this.gunaImageCheckBox3.Click += this.gunaImageCheckBox3_Click;
			this.gunaImageCheckBox2.ImageCheckedOff = Resources.movement_desativado;
			this.gunaImageCheckBox2.ImageCheckedOn = Resources.movement_ativado1;
			this.gunaImageCheckBox2.ImageSize = new Size(20, 20);
			this.gunaImageCheckBox2.Location = new Point(14, 209);
			this.gunaImageCheckBox2.Name = "gunaImageCheckBox2";
			this.gunaImageCheckBox2.Size = new Size(51, 38);
			this.gunaImageCheckBox2.TabIndex = 1;
			this.gunaImageCheckBox2.Click += this.gunaImageCheckBox2_Click;
			this.gunaImageCheckBox1.BackColor = Color.FromArgb(10, 10, 10);
			this.gunaImageCheckBox1.Checked = true;
			this.gunaImageCheckBox1.ImageCheckedOff = Resources.combat_ativado;
			this.gunaImageCheckBox1.ImageCheckedOn = Resources.combat_desativado;
			this.gunaImageCheckBox1.ImageSize = new Size(20, 20);
			this.gunaImageCheckBox1.Location = new Point(14, 165);
			this.gunaImageCheckBox1.Name = "gunaImageCheckBox1";
			this.gunaImageCheckBox1.Size = new Size(51, 38);
			this.gunaImageCheckBox1.TabIndex = 1;
			this.gunaImageCheckBox1.Click += this.gunaImageCheckBox1_Click;
			this.gunaLabel81.AutoSize = true;
			this.gunaLabel81.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel81.ForeColor = Color.Silver;
			this.gunaLabel81.Location = new Point(34, 348);
			this.gunaLabel81.Name = "gunaLabel81";
			this.gunaLabel81.Size = new Size(0, 13);
			this.gunaLabel81.TabIndex = 1;
			this.gunaLabel81.Visible = false;
			this.gunaLabel81.Click += this.gunaLabel79_Click;
			this.gunaLabel80.AutoSize = true;
			this.gunaLabel80.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel80.ForeColor = Color.Silver;
			this.gunaLabel80.Location = new Point(34, 312);
			this.gunaLabel80.Name = "gunaLabel80";
			this.gunaLabel80.Size = new Size(0, 13);
			this.gunaLabel80.TabIndex = 1;
			this.gunaLabel80.Visible = false;
			this.gunaLabel80.Click += this.gunaLabel79_Click;
			this.gunaLabel79.AutoSize = true;
			this.gunaLabel79.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel79.ForeColor = Color.Silver;
			this.gunaLabel79.Location = new Point(34, 120);
			this.gunaLabel79.Name = "gunaLabel79";
			this.gunaLabel79.Size = new Size(0, 13);
			this.gunaLabel79.TabIndex = 1;
			this.gunaLabel79.Visible = false;
			this.gunaLabel79.Click += this.gunaLabel79_Click;
			this.gunaLabel78.AutoSize = true;
			this.gunaLabel78.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel78.ForeColor = Color.Silver;
			this.gunaLabel78.Location = new Point(34, 141);
			this.gunaLabel78.Name = "gunaLabel78";
			this.gunaLabel78.Size = new Size(0, 13);
			this.gunaLabel78.TabIndex = 1;
			this.gunaLabel78.Visible = false;
			this.gunaLabel77.AutoSize = true;
			this.gunaLabel77.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel77.ForeColor = Color.Silver;
			this.gunaLabel77.Location = new Point(11, 141);
			this.gunaLabel77.Name = "gunaLabel77";
			this.gunaLabel77.Size = new Size(0, 13);
			this.gunaLabel77.TabIndex = 1;
			this.gunaLabel77.Visible = false;
			this.gunaLabel76.AutoSize = true;
			this.gunaLabel76.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel76.ForeColor = Color.Silver;
			this.gunaLabel76.Location = new Point(11, 114);
			this.gunaLabel76.Name = "gunaLabel76";
			this.gunaLabel76.Size = new Size(0, 13);
			this.gunaLabel76.TabIndex = 1;
			this.gunaLabel76.Visible = false;
			this.gunaLabel75.AutoSize = true;
			this.gunaLabel75.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel75.ForeColor = Color.Silver;
			this.gunaLabel75.Location = new Point(11, 88);
			this.gunaLabel75.Name = "gunaLabel75";
			this.gunaLabel75.Size = new Size(0, 13);
			this.gunaLabel75.TabIndex = 1;
			this.gunaLabel75.Visible = false;
			this.gunaLabel86.AutoSize = true;
			this.gunaLabel86.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel86.ForeColor = Color.Silver;
			this.gunaLabel86.Location = new Point(34, 441);
			this.gunaLabel86.Name = "gunaLabel86";
			this.gunaLabel86.Size = new Size(17, 13);
			this.gunaLabel86.TabIndex = 1;
			this.gunaLabel86.Text = "oi";
			this.gunaLabel86.Visible = false;
			this.gunaLabel85.AutoSize = true;
			this.gunaLabel85.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel85.ForeColor = Color.Silver;
			this.gunaLabel85.Location = new Point(17, 399);
			this.gunaLabel85.Name = "gunaLabel85";
			this.gunaLabel85.Size = new Size(0, 13);
			this.gunaLabel85.TabIndex = 1;
			this.gunaLabel85.Visible = false;
			this.gunaLabel83.AutoSize = true;
			this.gunaLabel83.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel83.ForeColor = Color.Silver;
			this.gunaLabel83.Location = new Point(17, 343);
			this.gunaLabel83.Name = "gunaLabel83";
			this.gunaLabel83.Size = new Size(0, 13);
			this.gunaLabel83.TabIndex = 1;
			this.gunaLabel83.Visible = false;
			this.gunaLabel84.AutoSize = true;
			this.gunaLabel84.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel84.ForeColor = Color.Silver;
			this.gunaLabel84.Location = new Point(17, 369);
			this.gunaLabel84.Name = "gunaLabel84";
			this.gunaLabel84.Size = new Size(0, 13);
			this.gunaLabel84.TabIndex = 1;
			this.gunaLabel84.Visible = false;
			this.gunaLabel82.AutoSize = true;
			this.gunaLabel82.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel82.ForeColor = Color.Silver;
			this.gunaLabel82.Location = new Point(17, 313);
			this.gunaLabel82.Name = "gunaLabel82";
			this.gunaLabel82.Size = new Size(0, 13);
			this.gunaLabel82.TabIndex = 1;
			this.gunaLabel82.Visible = false;
			this.gunaLabel74.AutoSize = true;
			this.gunaLabel74.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel74.ForeColor = Color.Silver;
			this.gunaLabel74.Location = new Point(11, 64);
			this.gunaLabel74.Name = "gunaLabel74";
			this.gunaLabel74.Size = new Size(0, 13);
			this.gunaLabel74.TabIndex = 1;
			this.gunaLabel74.Visible = false;
			this.gunaLabel73.AutoSize = true;
			this.gunaLabel73.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel73.ForeColor = Color.Silver;
			this.gunaLabel73.Location = new Point(11, 34);
			this.gunaLabel73.Name = "gunaLabel73";
			this.gunaLabel73.Size = new Size(0, 13);
			this.gunaLabel73.TabIndex = 1;
			this.gunaLabel73.Visible = false;
			this.gunaLabel33.AutoSize = true;
			this.gunaLabel33.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.gunaLabel33.ForeColor = Color.Silver;
			this.gunaLabel33.Location = new Point(11, 477);
			this.gunaLabel33.Name = "gunaLabel33";
			this.gunaLabel33.Size = new Size(17, 13);
			this.gunaLabel33.TabIndex = 1;
			this.gunaLabel33.Text = "oi";
			this.gunaLabel33.Visible = false;
			this.timer1.Tick += this.timer1_Tick;
			this.timer2.Tick += this.timer2_Tick;
			this.WTAP.Tick += this.timer3_Tick;
			this.AutoClicker.Tick += this.AutoClicker_Tick;
			this.STAP.Tick += this.timer4_Tick;
			this.SPRINT.Tick += this.SPRINT_Tick;
			this.ANTIAFK.Interval = 400;
			this.ANTIAFK.Tick += this.ANTIAFK_Tick;
			this.macmelt.Interval = 400;
			this.macmelt.Tick += this.macmelt_Tick;
			this.RIGHTCLICKER.Tick += this.RIGHTCLICKER_Tick;
			this.timer3.Interval = 1;
			this.timer3.Tick += this.timer3_Tick_1;
			this.STOPAC.Tick += this.STOPAC_Tick;
			this.CSPRINT.Tick += this.CSPRINT_Tick;
			this.AUTOBLOCK.Interval = 20;
			this.AUTOBLOCK.Tick += this.AUTOBLOCK_Tick;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(15, 15, 15);
			base.ClientSize = new Size(807, 567);
			base.Controls.Add(this.gunaShadowPanel1);
			this.ForeColor = Color.White;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Form1";
			base.ShowIcon = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.TransparencyKey = Color.FromArgb(1, 1, 1);
			base.Load += this.Form1_Load;
			this.gunaShadowPanel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gunaPanel142.ResumeLayout(false);
			this.gunaPanel142.PerformLayout();
			this.gunaPanel3.ResumeLayout(false);
			this.gunaPanel3.PerformLayout();
			this.gunaPanel41.ResumeLayout(false);
			this.gunaPanel41.PerformLayout();
			this.gunaPanel39.ResumeLayout(false);
			this.gunaPanel39.PerformLayout();
			this.gunaPanel4.ResumeLayout(false);
			this.gunaPanel4.PerformLayout();
			this.gunaPanel13.ResumeLayout(false);
			this.gunaPanel13.PerformLayout();
			this.gunaPanel44.ResumeLayout(false);
			this.gunaPanel44.PerformLayout();
			this.gunaPanel14.ResumeLayout(false);
			this.gunaPanel14.PerformLayout();
			this.gunaPanel17.ResumeLayout(false);
			this.gunaPanel17.PerformLayout();
			this.gunaPanel19.ResumeLayout(false);
			this.gunaPanel19.PerformLayout();
			this.gunaPanel29.ResumeLayout(false);
			this.gunaPanel29.PerformLayout();
			this.gunaPanel24.ResumeLayout(false);
			this.gunaPanel24.PerformLayout();
			this.gunaPanel27.ResumeLayout(false);
			this.gunaPanel27.PerformLayout();
			this.gunaPanel54.ResumeLayout(false);
			this.gunaPanel54.PerformLayout();
			this.gunaPanel49.ResumeLayout(false);
			this.gunaPanel49.PerformLayout();
			this.gunaPanel34.ResumeLayout(false);
			this.gunaPanel34.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.gunaPanel84.ResumeLayout(false);
			this.gunaPanel84.PerformLayout();
			this.gunaPanel143.ResumeLayout(false);
			this.gunaPanel143.PerformLayout();
			this.gunaPanel82.ResumeLayout(false);
			this.gunaPanel82.PerformLayout();
			this.gunaPanel72.ResumeLayout(false);
			this.gunaPanel72.PerformLayout();
			this.gunaPanel76.ResumeLayout(false);
			this.gunaPanel76.PerformLayout();
			this.gunaPanel77.ResumeLayout(false);
			this.gunaPanel77.PerformLayout();
			this.gunaPanel94.ResumeLayout(false);
			this.gunaPanel94.PerformLayout();
			this.gunaPanel62.ResumeLayout(false);
			this.gunaPanel62.PerformLayout();
			this.gunaPanel66.ResumeLayout(false);
			this.gunaPanel66.PerformLayout();
			this.gunaPanel67.ResumeLayout(false);
			this.gunaPanel67.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.gunaPanel98.ResumeLayout(false);
			this.gunaPanel98.PerformLayout();
			this.gunaPanel112.ResumeLayout(false);
			this.gunaPanel112.PerformLayout();
			this.gunaPanel125.ResumeLayout(false);
			this.gunaPanel125.PerformLayout();
			this.gunaPanel136.ResumeLayout(false);
			this.gunaPanel136.PerformLayout();
			this.gunaPanel126.ResumeLayout(false);
			this.gunaPanel126.PerformLayout();
			this.gunaPanel119.ResumeLayout(false);
			this.gunaPanel119.PerformLayout();
			this.gunaPanel113.ResumeLayout(false);
			this.gunaPanel113.PerformLayout();
			this.gunaPanel96.ResumeLayout(false);
			this.gunaPanel96.PerformLayout();
			this.gunaPanel1.ResumeLayout(false);
			this.gunaPanel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private bool shouldClick;

		// Token: 0x04000002 RID: 2
		private Random rnd = new Random();

		// Token: 0x04000003 RID: 3
		private int esquerda;

		// Token: 0x04000004 RID: 4
		private float SelectedRainbowNumber;

		// Token: 0x04000005 RID: 5
		private bool MouseMoving;

		// Token: 0x04000006 RID: 6
		private Color SelectedColor;

		// Token: 0x04000007 RID: 7
		private string HWID;

		// Token: 0x04000008 RID: 8
		private uint pid;

		// Token: 0x04000009 RID: 9
		private static Random random = new Random();

		// Token: 0x0400000A RID: 10
		private string prefetchPath;

		// Token: 0x0400000B RID: 11
		private DotNetScanMemory_SmoLL Reach1 = new DotNetScanMemory_SmoLL();

		// Token: 0x0400000C RID: 12
		private DotNetScanMemory_SmoLL Reach2 = new DotNetScanMemory_SmoLL();

		// Token: 0x0400000D RID: 13
		private List<IntPtr> R = new List<IntPtr>();

		// Token: 0x0400000E RID: 14
		private IntPtr[] Reachb;

		// Token: 0x0400000F RID: 15
		private IntPtr[] Reach;

		// Token: 0x04000010 RID: 16
		private List<IntPtr> R1 = new List<IntPtr>();

		// Token: 0x04000011 RID: 17
		private double oldr = 3.0;

		// Token: 0x04000012 RID: 18
		private bool alcance = false;

		// Token: 0x04000013 RID: 19
		private double newr;

		// Token: 0x04000014 RID: 20
		private static IntPtr[] pl1;

		// Token: 0x04000015 RID: 21
		private static IntPtr[] pl4;

		// Token: 0x04000016 RID: 22
		private static DotNetScanMemory_SmoLL pl8 = new DotNetScanMemory_SmoLL();

		// Token: 0x04000017 RID: 23
		private static DotNetScanMemory_SmoLL pl2 = new DotNetScanMemory_SmoLL();

		// Token: 0x04000018 RID: 24
		private VAMemory vamemory_0 = new VAMemory("javaw");

		// Token: 0x04000019 RID: 25
		private IContainer components = null;

		// Token: 0x0400001A RID: 26
		private GunaShadowPanel gunaShadowPanel1;

		// Token: 0x0400001B RID: 27
		private GunaPanel gunaPanel1;

		// Token: 0x0400001C RID: 28
		private GunaPanel gunaPanel2;

		// Token: 0x0400001D RID: 29
		private GunaImageCheckBox gunaImageCheckBox1;

		// Token: 0x0400001E RID: 30
		private GunaImageCheckBox gunaImageCheckBox3;

		// Token: 0x0400001F RID: 31
		private GunaImageCheckBox gunaImageCheckBox2;

		// Token: 0x04000020 RID: 32
		private GunaPanel gunaPanel3;

		// Token: 0x04000021 RID: 33
		private GunaPanel gunaPanel5;

		// Token: 0x04000022 RID: 34
		private GunaPanel gunaPanel9;

		// Token: 0x04000023 RID: 35
		private GunaPanel gunaPanel8;

		// Token: 0x04000024 RID: 36
		private GunaPanel gunaPanel7;

		// Token: 0x04000025 RID: 37
		private GunaPanel gunaPanel6;

		// Token: 0x04000026 RID: 38
		private GunaLabel gunaLabel1;

		// Token: 0x04000027 RID: 39
		private GunaPanel gunaPanel29;

		// Token: 0x04000028 RID: 40
		private GunaLabel gunaLabel6;

		// Token: 0x04000029 RID: 41
		private GunaPanel gunaPanel30;

		// Token: 0x0400002A RID: 42
		private GunaPanel gunaPanel31;

		// Token: 0x0400002B RID: 43
		private GunaPanel gunaPanel32;

		// Token: 0x0400002C RID: 44
		private GunaPanel gunaPanel33;

		// Token: 0x0400002D RID: 45
		private GunaPanel gunaPanel34;

		// Token: 0x0400002E RID: 46
		private GunaLabel gunaLabel7;

		// Token: 0x0400002F RID: 47
		private GunaPanel gunaPanel35;

		// Token: 0x04000030 RID: 48
		private GunaPanel gunaPanel36;

		// Token: 0x04000031 RID: 49
		private GunaPanel gunaPanel37;

		// Token: 0x04000032 RID: 50
		private GunaPanel gunaPanel38;

		// Token: 0x04000033 RID: 51
		private GunaPanel gunaPanel40;

		// Token: 0x04000034 RID: 52
		private GunaPanel gunaPanel39;

		// Token: 0x04000035 RID: 53
		private GunaLabel gunaLabel8;

		// Token: 0x04000036 RID: 54
		private BunifuSlider bunifuSlider1;

		// Token: 0x04000037 RID: 55
		private GunaLabel gunaLabel11;

		// Token: 0x04000038 RID: 56
		private GunaLabel gunaLabel10;

		// Token: 0x04000039 RID: 57
		private GunaPanel gunaPanel42;

		// Token: 0x0400003A RID: 58
		private GunaPanel gunaPanel41;

		// Token: 0x0400003B RID: 59
		private GunaLabel gunaLabel9;

		// Token: 0x0400003C RID: 60
		private BunifuSlider bunifuSlider2;

		// Token: 0x0400003D RID: 61
		private GunaShadowPanel gunaShadowPanel5;

		// Token: 0x0400003E RID: 62
		private GunaShadowPanel gunaShadowPanel3;

		// Token: 0x0400003F RID: 63
		private GunaShadowPanel gunaShadowPanel4;

		// Token: 0x04000040 RID: 64
		private GunaShadowPanel gunaShadowPanel2;

		// Token: 0x04000041 RID: 65
		private GunaAdvenceButton gunaAdvenceButton1;

		// Token: 0x04000042 RID: 66
		private GunaPanel gunaPanel43;

		// Token: 0x04000043 RID: 67
		private GunaLabel gunaLabel14;

		// Token: 0x04000044 RID: 68
		private GunaLabel gunaLabel15;

		// Token: 0x04000045 RID: 69
		private GunaLabel gunaLabel13;

		// Token: 0x04000046 RID: 70
		private GunaLabel gunaLabel12;

		// Token: 0x04000047 RID: 71
		private GunaPanel gunaPanel4;

		// Token: 0x04000048 RID: 72
		private GunaLabel gunaLabel18;

		// Token: 0x04000049 RID: 73
		private GunaAdvenceButton gunaAdvenceButton3;

		// Token: 0x0400004A RID: 74
		private GunaAdvenceButton gunaAdvenceButton4;

		// Token: 0x0400004B RID: 75
		private GunaShadowPanel gunaShadowPanel9;

		// Token: 0x0400004C RID: 76
		private GunaLabel gunaLabel19;

		// Token: 0x0400004D RID: 77
		private GunaAdvenceButton gunaAdvenceButton5;

		// Token: 0x0400004E RID: 78
		private GunaLabel gunaLabel20;

		// Token: 0x0400004F RID: 79
		private GunaPanel gunaPanel11;

		// Token: 0x04000050 RID: 80
		private GunaPanel gunaPanel12;

		// Token: 0x04000051 RID: 81
		private GunaPanel gunaPanel13;

		// Token: 0x04000052 RID: 82
		private GunaLabel gunaLabel21;

		// Token: 0x04000053 RID: 83
		private GunaPanel gunaPanel10;

		// Token: 0x04000054 RID: 84
		private BunifuSlider bunifuSlider3;

		// Token: 0x04000055 RID: 85
		private GunaPanel gunaPanel44;

		// Token: 0x04000056 RID: 86
		private GunaLabel gunaLabel22;

		// Token: 0x04000057 RID: 87
		private BunifuSlider bunifuSlider4;

		// Token: 0x04000058 RID: 88
		private GunaLabel gunaLabel23;

		// Token: 0x04000059 RID: 89
		private GunaPanel gunaPanel45;

		// Token: 0x0400005A RID: 90
		private GunaPanel gunaPanel46;

		// Token: 0x0400005B RID: 91
		private GunaPanel gunaPanel47;

		// Token: 0x0400005C RID: 92
		private GunaPanel gunaPanel48;

		// Token: 0x0400005D RID: 93
		private GunaAdvenceButton gunaAdvenceButton8;

		// Token: 0x0400005E RID: 94
		private GunaAdvenceButton gunaAdvenceButton7;

		// Token: 0x0400005F RID: 95
		private GunaPanel gunaPanel24;

		// Token: 0x04000060 RID: 96
		private GunaLabel gunaLabel2;

		// Token: 0x04000061 RID: 97
		private GunaAdvenceButton gunaAdvenceButton16;

		// Token: 0x04000062 RID: 98
		private GunaLabel gunaLabel5;

		// Token: 0x04000063 RID: 99
		private GunaPanel gunaPanel25;

		// Token: 0x04000064 RID: 100
		private GunaPanel gunaPanel26;

		// Token: 0x04000065 RID: 101
		private GunaPanel gunaPanel27;

		// Token: 0x04000066 RID: 102
		private GunaLabel gunaLabel25;

		// Token: 0x04000067 RID: 103
		private GunaPanel gunaPanel28;

		// Token: 0x04000068 RID: 104
		private BunifuSlider bunifuSlider7;

		// Token: 0x04000069 RID: 105
		private GunaPanel gunaPanel49;

		// Token: 0x0400006A RID: 106
		private GunaLabel gunaLabel26;

		// Token: 0x0400006B RID: 107
		private BunifuSlider bunifuSlider8;

		// Token: 0x0400006C RID: 108
		private GunaLabel gunaLabel27;

		// Token: 0x0400006D RID: 109
		private GunaPanel gunaPanel50;

		// Token: 0x0400006E RID: 110
		private GunaPanel gunaPanel51;

		// Token: 0x0400006F RID: 111
		private GunaPanel gunaPanel52;

		// Token: 0x04000070 RID: 112
		private GunaPanel gunaPanel53;

		// Token: 0x04000071 RID: 113
		private GunaPanel gunaPanel14;

		// Token: 0x04000072 RID: 114
		private GunaAdvenceButton gunaAdvenceButton9;

		// Token: 0x04000073 RID: 115
		private GunaAdvenceButton gunaAdvenceButton10;

		// Token: 0x04000074 RID: 116
		private GunaLabel gunaLabel3;

		// Token: 0x04000075 RID: 117
		private GunaAdvenceButton gunaAdvenceButton12;

		// Token: 0x04000076 RID: 118
		private GunaLabel gunaLabel4;

		// Token: 0x04000077 RID: 119
		private GunaPanel gunaPanel15;

		// Token: 0x04000078 RID: 120
		private GunaPanel gunaPanel16;

		// Token: 0x04000079 RID: 121
		private GunaPanel gunaPanel17;

		// Token: 0x0400007A RID: 122
		private GunaLabel gunaLabel16;

		// Token: 0x0400007B RID: 123
		private GunaPanel gunaPanel18;

		// Token: 0x0400007C RID: 124
		private BunifuSlider bunifuSlider5;

		// Token: 0x0400007D RID: 125
		private GunaPanel gunaPanel19;

		// Token: 0x0400007E RID: 126
		private GunaLabel gunaLabel17;

		// Token: 0x0400007F RID: 127
		private BunifuSlider bunifuSlider6;

		// Token: 0x04000080 RID: 128
		private GunaLabel gunaLabel24;

		// Token: 0x04000081 RID: 129
		private GunaPanel gunaPanel20;

		// Token: 0x04000082 RID: 130
		private GunaPanel gunaPanel21;

		// Token: 0x04000083 RID: 131
		private GunaPanel gunaPanel22;

		// Token: 0x04000084 RID: 132
		private GunaPanel gunaPanel23;

		// Token: 0x04000085 RID: 133
		private BunifuDropdown bunifuDropdown2;

		// Token: 0x04000086 RID: 134
		private GunaNumeric gunaNumeric3;

		// Token: 0x04000087 RID: 135
		private GunaAdvenceButton gunaAdvenceButton18;

		// Token: 0x04000088 RID: 136
		private GunaNumeric gunaNumeric2;

		// Token: 0x04000089 RID: 137
		private GunaNumeric gunaNumeric1;

		// Token: 0x0400008A RID: 138
		private GunaLabel gunaLabel32;

		// Token: 0x0400008B RID: 139
		private GunaLabel gunaLabel31;

		// Token: 0x0400008C RID: 140
		private GunaPanel gunaPanel57;

		// Token: 0x0400008D RID: 141
		private BunifuDropdown bunifuDropdown1;

		// Token: 0x0400008E RID: 142
		private GunaAdvenceButton gunaAdvenceButton17;

		// Token: 0x0400008F RID: 143
		private GunaPanel gunaPanel56;

		// Token: 0x04000090 RID: 144
		private GunaAdvenceButton gunaAdvenceButton14;

		// Token: 0x04000091 RID: 145
		private GunaAdvenceButton gunaAdvenceButton13;

		// Token: 0x04000092 RID: 146
		private GunaLabel gunaLabel30;

		// Token: 0x04000093 RID: 147
		private GunaLabel gunaLabel29;

		// Token: 0x04000094 RID: 148
		private GunaPanel gunaPanel55;

		// Token: 0x04000095 RID: 149
		private GunaShadowPanel gunaShadowPanel6;

		// Token: 0x04000096 RID: 150
		private GunaPanel gunaPanel54;

		// Token: 0x04000097 RID: 151
		private GunaLabel gunaLabel28;

		// Token: 0x04000098 RID: 152
		private BunifuSlider bunifuSlider9;

		// Token: 0x04000099 RID: 153
		private GunaPanel gunaPanel61;

		// Token: 0x0400009A RID: 154
		private GunaPanel gunaPanel60;

		// Token: 0x0400009B RID: 155
		private GunaPanel gunaPanel59;

		// Token: 0x0400009C RID: 156
		private GunaPanel gunaPanel58;

		// Token: 0x0400009D RID: 157
		private TabControl tabControl1;

		// Token: 0x0400009E RID: 158
		private TabPage tabPage1;

		// Token: 0x0400009F RID: 159
		private TabPage tabPage2;

		// Token: 0x040000A0 RID: 160
		private GunaLabel gunaLabel33;

		// Token: 0x040000A1 RID: 161
		private TabPage tabPage3;

		// Token: 0x040000A2 RID: 162
		private GunaPanel gunaPanel62;

		// Token: 0x040000A3 RID: 163
		private GunaAdvenceButton gunaAdvenceButton20;

		// Token: 0x040000A4 RID: 164
		private GunaPanel gunaPanel63;

		// Token: 0x040000A5 RID: 165
		private GunaLabel gunaLabel38;

		// Token: 0x040000A6 RID: 166
		private GunaLabel gunaLabel39;

		// Token: 0x040000A7 RID: 167
		private GunaPanel gunaPanel64;

		// Token: 0x040000A8 RID: 168
		private GunaPanel gunaPanel65;

		// Token: 0x040000A9 RID: 169
		private GunaPanel gunaPanel66;

		// Token: 0x040000AA RID: 170
		private GunaLabel gunaLabel40;

		// Token: 0x040000AB RID: 171
		private BunifuSlider bunifuSlider10;

		// Token: 0x040000AC RID: 172
		private GunaPanel gunaPanel67;

		// Token: 0x040000AD RID: 173
		private GunaLabel gunaLabel41;

		// Token: 0x040000AE RID: 174
		private BunifuSlider bunifuSlider11;

		// Token: 0x040000AF RID: 175
		private GunaLabel gunaLabel42;

		// Token: 0x040000B0 RID: 176
		private GunaPanel gunaPanel68;

		// Token: 0x040000B1 RID: 177
		private GunaPanel gunaPanel69;

		// Token: 0x040000B2 RID: 178
		private GunaPanel gunaPanel70;

		// Token: 0x040000B3 RID: 179
		private GunaPanel gunaPanel71;

		// Token: 0x040000B4 RID: 180
		private GunaPanel gunaPanel82;

		// Token: 0x040000B5 RID: 181
		private GunaAdvenceButton gunaAdvenceButton21;

		// Token: 0x040000B6 RID: 182
		private GunaPanel gunaPanel83;

		// Token: 0x040000B7 RID: 183
		private GunaLabel gunaLabel48;

		// Token: 0x040000B8 RID: 184
		private GunaPanel gunaPanel88;

		// Token: 0x040000B9 RID: 185
		private GunaPanel gunaPanel89;

		// Token: 0x040000BA RID: 186
		private GunaPanel gunaPanel90;

		// Token: 0x040000BB RID: 187
		private GunaPanel gunaPanel91;

		// Token: 0x040000BC RID: 188
		private GunaPanel gunaPanel72;

		// Token: 0x040000BD RID: 189
		private GunaAdvenceButton gunaAdvenceButton19;

		// Token: 0x040000BE RID: 190
		private GunaPanel gunaPanel73;

		// Token: 0x040000BF RID: 191
		private GunaLabel gunaLabel34;

		// Token: 0x040000C0 RID: 192
		private GunaLabel gunaLabel35;

		// Token: 0x040000C1 RID: 193
		private GunaPanel gunaPanel74;

		// Token: 0x040000C2 RID: 194
		private GunaPanel gunaPanel75;

		// Token: 0x040000C3 RID: 195
		private GunaPanel gunaPanel76;

		// Token: 0x040000C4 RID: 196
		private GunaLabel gunaLabel36;

		// Token: 0x040000C5 RID: 197
		private BunifuSlider bunifuSlider12;

		// Token: 0x040000C6 RID: 198
		private GunaPanel gunaPanel77;

		// Token: 0x040000C7 RID: 199
		private GunaLabel gunaLabel37;

		// Token: 0x040000C8 RID: 200
		private BunifuSlider bunifuSlider13;

		// Token: 0x040000C9 RID: 201
		private GunaLabel gunaLabel43;

		// Token: 0x040000CA RID: 202
		private GunaPanel gunaPanel78;

		// Token: 0x040000CB RID: 203
		private GunaPanel gunaPanel79;

		// Token: 0x040000CC RID: 204
		private GunaPanel gunaPanel80;

		// Token: 0x040000CD RID: 205
		private GunaPanel gunaPanel81;

		// Token: 0x040000CE RID: 206
		private GunaPanel gunaPanel84;

		// Token: 0x040000CF RID: 207
		private GunaLabel gunaLabel45;

		// Token: 0x040000D0 RID: 208
		private GunaShadowPanel gunaShadowPanel8;

		// Token: 0x040000D1 RID: 209
		private GunaAdvenceButton gunaAdvenceButton22;

		// Token: 0x040000D2 RID: 210
		private GunaPanel gunaPanel85;

		// Token: 0x040000D3 RID: 211
		private GunaLabel gunaLabel46;

		// Token: 0x040000D4 RID: 212
		private GunaPanel gunaPanel86;

		// Token: 0x040000D5 RID: 213
		private GunaPanel gunaPanel87;

		// Token: 0x040000D6 RID: 214
		private GunaPanel gunaPanel92;

		// Token: 0x040000D7 RID: 215
		private GunaPanel gunaPanel93;

		// Token: 0x040000D8 RID: 216
		private GunaLabel gunaLabel44;

		// Token: 0x040000D9 RID: 217
		private GunaShadowPanel gunaShadowPanel7;

		// Token: 0x040000DA RID: 218
		private GunaPanel gunaPanel94;

		// Token: 0x040000DB RID: 219
		private GunaAdvenceButton gunaAdvenceButton23;

		// Token: 0x040000DC RID: 220
		private GunaPanel gunaPanel95;

		// Token: 0x040000DD RID: 221
		private GunaLabel gunaLabel47;

		// Token: 0x040000DE RID: 222
		private GunaLabel gunaLabel49;

		// Token: 0x040000DF RID: 223
		private GunaLabel gunaLabel52;

		// Token: 0x040000E0 RID: 224
		private GunaPanel gunaPanel100;

		// Token: 0x040000E1 RID: 225
		private GunaPanel gunaPanel101;

		// Token: 0x040000E2 RID: 226
		private GunaPanel gunaPanel102;

		// Token: 0x040000E3 RID: 227
		private GunaPanel gunaPanel103;

		// Token: 0x040000E4 RID: 228
		private GunaPanel gunaPanel96;

		// Token: 0x040000E5 RID: 229
		private GunaAdvenceButton gunaAdvenceButton24;

		// Token: 0x040000E6 RID: 230
		private GunaPanel gunaPanel97;

		// Token: 0x040000E7 RID: 231
		private GunaLabel gunaLabel55;

		// Token: 0x040000E8 RID: 232
		private GunaPanel gunaPanel106;

		// Token: 0x040000E9 RID: 233
		private GunaPanel gunaPanel107;

		// Token: 0x040000EA RID: 234
		private GunaPanel gunaPanel108;

		// Token: 0x040000EB RID: 235
		private GunaPanel gunaPanel109;

		// Token: 0x040000EC RID: 236
		private GunaPanel gunaPanel98;

		// Token: 0x040000ED RID: 237
		private GunaLabel gunaLabel57;

		// Token: 0x040000EE RID: 238
		private GunaLabel gunaLabel56;

		// Token: 0x040000EF RID: 239
		private GunaShadowPanel gunaShadowPanel11;

		// Token: 0x040000F0 RID: 240
		private GunaShadowPanel gunaShadowPanel10;

		// Token: 0x040000F1 RID: 241
		private GunaPanel gunaPanel99;

		// Token: 0x040000F2 RID: 242
		private GunaPanel gunaPanel112;

		// Token: 0x040000F3 RID: 243
		private GunaLabel gunaLabel54;

		// Token: 0x040000F4 RID: 244
		private BunifuSlider bunifuSlider14;

		// Token: 0x040000F5 RID: 245
		private GunaLabel gunaLabel53;

		// Token: 0x040000F6 RID: 246
		private GunaPanel gunaPanel104;

		// Token: 0x040000F7 RID: 247
		private GunaPanel gunaPanel105;

		// Token: 0x040000F8 RID: 248
		private GunaPanel gunaPanel110;

		// Token: 0x040000F9 RID: 249
		private GunaPanel gunaPanel111;

		// Token: 0x040000FA RID: 250
		private GunaPanel gunaPanel119;

		// Token: 0x040000FB RID: 251
		private GunaAdvenceButton gunaAdvenceButton26;

		// Token: 0x040000FC RID: 252
		private GunaPanel gunaPanel120;

		// Token: 0x040000FD RID: 253
		private GunaLabel gunaLabel61;

		// Token: 0x040000FE RID: 254
		private GunaPanel gunaPanel121;

		// Token: 0x040000FF RID: 255
		private GunaPanel gunaPanel122;

		// Token: 0x04000100 RID: 256
		private GunaPanel gunaPanel123;

		// Token: 0x04000101 RID: 257
		private GunaPanel gunaPanel124;

		// Token: 0x04000102 RID: 258
		private GunaPanel gunaPanel113;

		// Token: 0x04000103 RID: 259
		private GunaTextBox gunaTextBox2;

		// Token: 0x04000104 RID: 260
		private GunaAdvenceButton gunaAdvenceButton25;

		// Token: 0x04000105 RID: 261
		private GunaPanel gunaPanel114;

		// Token: 0x04000106 RID: 262
		private GunaLabel gunaLabel58;

		// Token: 0x04000107 RID: 263
		private GunaLabel gunaLabel59;

		// Token: 0x04000108 RID: 264
		private GunaPanel gunaPanel115;

		// Token: 0x04000109 RID: 265
		private GunaPanel gunaPanel116;

		// Token: 0x0400010A RID: 266
		private GunaPanel gunaPanel117;

		// Token: 0x0400010B RID: 267
		private GunaPanel gunaPanel118;

		// Token: 0x0400010C RID: 268
		private GunaTextBox gunaTextBox1;

		// Token: 0x0400010D RID: 269
		private GunaLabel gunaLabel50;

		// Token: 0x0400010E RID: 270
		private GunaPanel gunaPanel125;

		// Token: 0x0400010F RID: 271
		private GunaLabel gunaLabel62;

		// Token: 0x04000110 RID: 272
		private GunaShadowPanel gunaShadowPanel13;

		// Token: 0x04000111 RID: 273
		private GunaLabel gunaLabel63;

		// Token: 0x04000112 RID: 274
		private GunaPanel gunaPanel127;

		// Token: 0x04000113 RID: 275
		private GunaPanel gunaPanel128;

		// Token: 0x04000114 RID: 276
		private GunaPanel gunaPanel129;

		// Token: 0x04000115 RID: 277
		private GunaPanel gunaPanel130;

		// Token: 0x04000116 RID: 278
		private GunaAdvenceButton gunaAdvenceButton27;

		// Token: 0x04000117 RID: 279
		private GunaLabel gunaLabel60;

		// Token: 0x04000118 RID: 280
		private GunaShadowPanel gunaShadowPanel12;

		// Token: 0x04000119 RID: 281
		private GunaLabel gunaLabel64;

		// Token: 0x0400011A RID: 282
		private GunaShadowPanel gunaShadowPanel14;

		// Token: 0x0400011B RID: 283
		private GunaPanel gunaPanel126;

		// Token: 0x0400011C RID: 284
		private GunaAdvenceButton gunaAdvenceButton28;

		// Token: 0x0400011D RID: 285
		private GunaLabel gunaLabel65;

		// Token: 0x0400011E RID: 286
		private GunaAdvenceButton gunaAdvenceButton29;

		// Token: 0x0400011F RID: 287
		private GunaPanel gunaPanel131;

		// Token: 0x04000120 RID: 288
		private GunaShadowPanel gunaShadowPanel15;

		// Token: 0x04000121 RID: 289
		private GunaLabel gunaLabel66;

		// Token: 0x04000122 RID: 290
		private GunaPanel gunaPanel132;

		// Token: 0x04000123 RID: 291
		private GunaPanel gunaPanel133;

		// Token: 0x04000124 RID: 292
		private GunaPanel gunaPanel134;

		// Token: 0x04000125 RID: 293
		private GunaPanel gunaPanel135;

		// Token: 0x04000126 RID: 294
		private GunaPanel gunaPanel136;

		// Token: 0x04000127 RID: 295
		private GunaTextBox gunaTextBox3;

		// Token: 0x04000128 RID: 296
		private GunaLabel gunaLabel67;

		// Token: 0x04000129 RID: 297
		private GunaAdvenceButton gunaAdvenceButton31;

		// Token: 0x0400012A RID: 298
		private GunaLabel gunaLabel69;

		// Token: 0x0400012B RID: 299
		private GunaPanel gunaPanel137;

		// Token: 0x0400012C RID: 300
		private GunaShadowPanel gunaShadowPanel16;

		// Token: 0x0400012D RID: 301
		private GunaLabel gunaLabel68;

		// Token: 0x0400012E RID: 302
		private GunaPanel gunaPanel138;

		// Token: 0x0400012F RID: 303
		private GunaPanel gunaPanel139;

		// Token: 0x04000130 RID: 304
		private GunaPanel gunaPanel140;

		// Token: 0x04000131 RID: 305
		private GunaPanel gunaPanel141;

		// Token: 0x04000132 RID: 306
		private Timer timer1;

		// Token: 0x04000133 RID: 307
		private GunaTextBox gunaTextBox4;

		// Token: 0x04000134 RID: 308
		private GunaTextBox gunaTextBox5;

		// Token: 0x04000135 RID: 309
		private GunaTextBox gunaTextBox6;

		// Token: 0x04000136 RID: 310
		private GunaTextBox gunaTextBox7;

		// Token: 0x04000137 RID: 311
		private Timer timer2;

		// Token: 0x04000138 RID: 312
		private Timer WTAP;

		// Token: 0x04000139 RID: 313
		private Timer AutoClicker;

		// Token: 0x0400013A RID: 314
		private Timer STAP;

		// Token: 0x0400013B RID: 315
		private Timer SPRINT;

		// Token: 0x0400013C RID: 316
		private GunaTextBox gunaTextBox8;

		// Token: 0x0400013D RID: 317
		private Timer ANTIAFK;

		// Token: 0x0400013E RID: 318
		private GunaLabel gunaLabel51;

		// Token: 0x0400013F RID: 319
		private GunaPanel gunaPanel142;

		// Token: 0x04000140 RID: 320
		private GunaPanel gunaPanel144;

		// Token: 0x04000141 RID: 321
		private Timer macmelt;

		// Token: 0x04000142 RID: 322
		private GunaLabel gunaLabel70;

		// Token: 0x04000143 RID: 323
		private Timer RIGHTCLICKER;

		// Token: 0x04000144 RID: 324
		private Timer timer3;

		// Token: 0x04000145 RID: 325
		private GunaPanel gunaPanel143;

		// Token: 0x04000146 RID: 326
		private GunaLabel gunaLabel71;

		// Token: 0x04000147 RID: 327
		private GunaShadowPanel gunaShadowPanel17;

		// Token: 0x04000148 RID: 328
		private GunaAdvenceButton gunaAdvenceButton2;

		// Token: 0x04000149 RID: 329
		private GunaPanel gunaPanel145;

		// Token: 0x0400014A RID: 330
		private GunaLabel gunaLabel72;

		// Token: 0x0400014B RID: 331
		private GunaPanel gunaPanel146;

		// Token: 0x0400014C RID: 332
		private GunaPanel gunaPanel147;

		// Token: 0x0400014D RID: 333
		private GunaPanel gunaPanel148;

		// Token: 0x0400014E RID: 334
		private GunaPanel gunaPanel149;

		// Token: 0x0400014F RID: 335
		private GunaLabel gunaLabel73;

		// Token: 0x04000150 RID: 336
		private GunaLabel gunaLabel78;

		// Token: 0x04000151 RID: 337
		private GunaLabel gunaLabel77;

		// Token: 0x04000152 RID: 338
		private GunaLabel gunaLabel76;

		// Token: 0x04000153 RID: 339
		private GunaLabel gunaLabel75;

		// Token: 0x04000154 RID: 340
		private GunaLabel gunaLabel74;

		// Token: 0x04000155 RID: 341
		private GunaLabel gunaLabel79;

		// Token: 0x04000156 RID: 342
		private GunaLabel gunaLabel80;

		// Token: 0x04000157 RID: 343
		private GunaLabel gunaLabel81;

		// Token: 0x04000158 RID: 344
		private Timer STOPAC;

		// Token: 0x04000159 RID: 345
		private GunaTextBox gunaTextBox9;

		// Token: 0x0400015A RID: 346
		private GunaLabel gunaLabel85;

		// Token: 0x0400015B RID: 347
		private GunaLabel gunaLabel83;

		// Token: 0x0400015C RID: 348
		private GunaLabel gunaLabel84;

		// Token: 0x0400015D RID: 349
		private GunaLabel gunaLabel82;

		// Token: 0x0400015E RID: 350
		private GunaLabel gunaLabel86;

		// Token: 0x0400015F RID: 351
		private Timer CSPRINT;

		// Token: 0x04000160 RID: 352
		private GunaLabel gunaLabel87;

		// Token: 0x04000161 RID: 353
		private GunaLabel gunaLabel88;

		// Token: 0x04000162 RID: 354
		private GunaLabel gunaLabel89;

		// Token: 0x04000163 RID: 355
		private GunaLabel gunaLabel90;

		// Token: 0x04000164 RID: 356
		private Timer AUTOBLOCK;
	}
}
