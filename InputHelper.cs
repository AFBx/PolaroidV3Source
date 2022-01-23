using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Steam_Setup
{
	// Token: 0x02000011 RID: 17
	public sealed class InputHelper
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x000178C7 File Offset: 0x00015AC7
		private InputHelper()
		{
		}

		// Token: 0x060000A1 RID: 161
		[DllImport("user32.dll")]
		private static extern IntPtr GetKeyboardLayout(uint idThread);

		// Token: 0x060000A2 RID: 162
		[DllImport("user32.dll")]
		private static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

		// Token: 0x060000A3 RID: 163 RVA: 0x000178D4 File Offset: 0x00015AD4
		public static void PressKey(Keys Key, bool HardwareKey = false)
		{
			bool flag = !HardwareKey;
			if (flag)
			{
				InputHelper.SetKeyState(Key, false);
				InputHelper.SetKeyState(Key, true);
			}
			else
			{
				InputHelper.SetHardwareKeyState(Key, false);
				InputHelper.SetHardwareKeyState(Key, true);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00017910 File Offset: 0x00015B10
		private static Keys ReplaceBadKeys(Keys Key)
		{
			Keys keys = Key;
			bool flag = keys.HasFlag(Keys.Control);
			if (flag)
			{
				keys = ((keys & (Keys.KeyCode | Keys.Shift | Keys.Alt)) | Keys.ControlKey);
			}
			bool flag2 = keys.HasFlag(Keys.Shift);
			if (flag2)
			{
				keys = ((keys & (Keys.KeyCode | Keys.Control | Keys.Alt)) | Keys.ShiftKey);
			}
			bool flag3 = keys.HasFlag(Keys.Alt);
			if (flag3)
			{
				keys = ((keys & (Keys.KeyCode | Keys.Shift | Keys.Control)) | Keys.Menu);
			}
			return keys;
		}

		// Token: 0x060000A5 RID: 165
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint nInputs, InputHelper.INPUT[] pInputs, int cbSize);

		// Token: 0x060000A6 RID: 166 RVA: 0x0001799C File Offset: 0x00015B9C
		public static void SetHardwareKeyState(Keys Key, bool KeyUp)
		{
			Key = InputHelper.ReplaceBadKeys(Key);
			InputHelper.KEYBDINPUT ki = new InputHelper.KEYBDINPUT
			{
				wVk = 0,
				time = 0,
				dwFlags = Conversions.ToUInteger(RuntimeHelpers.GetObjectValue(Operators.OrObject(InputHelper.KEYEVENTF.SCANCODE, RuntimeHelpers.GetObjectValue(KeyUp ? InputHelper.KEYEVENTF.KEYUP : ((InputHelper.KEYEVENTF)0U))))),
				dwExtraInfo = IntPtr.Zero
			};
			InputHelper.INPUTUNION u = new InputHelper.INPUTUNION
			{
				ki = ki
			};
			InputHelper.INPUT input = new InputHelper.INPUT
			{
				type = 1,
				U = u
			};
			InputHelper.SendInput(1U, new InputHelper.INPUT[]
			{
				input
			}, Marshal.SizeOf(typeof(InputHelper.INPUT)));
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00017A58 File Offset: 0x00015C58
		public static void SetKeyState(Keys Key, bool KeyUp)
		{
			Key = InputHelper.ReplaceBadKeys(Key);
			InputHelper.KEYBDINPUT ki = new InputHelper.KEYBDINPUT
			{
				wVk = checked((ushort)Key),
				wScan = 0,
				time = 0,
				dwFlags = Conversions.ToUInteger(RuntimeHelpers.GetObjectValue(KeyUp ? InputHelper.KEYEVENTF.KEYUP : ((InputHelper.KEYEVENTF)0U))),
				dwExtraInfo = IntPtr.Zero
			};
			InputHelper.INPUTUNION u = new InputHelper.INPUTUNION
			{
				ki = ki
			};
			InputHelper.INPUT input = new InputHelper.INPUT
			{
				type = 1,
				U = u
			};
			InputHelper.SendInput(1U, new InputHelper.INPUT[]
			{
				input
			}, Marshal.SizeOf(typeof(InputHelper.INPUT)));
		}

		// Token: 0x02000012 RID: 18
		private struct HARDWAREINPUT
		{
			// Token: 0x040001AD RID: 429
			public int uMsg;

			// Token: 0x040001AE RID: 430
			public short wParamL;

			// Token: 0x040001AF RID: 431
			public short wParamH;
		}

		// Token: 0x02000013 RID: 19
		private struct INPUT
		{
			// Token: 0x040001B0 RID: 432
			public int type;

			// Token: 0x040001B1 RID: 433
			public InputHelper.INPUTUNION U;
		}

		// Token: 0x02000014 RID: 20
		private enum INPUTTYPE : uint
		{
			// Token: 0x040001B3 RID: 435
			MOUSE,
			// Token: 0x040001B4 RID: 436
			KEYBOARD,
			// Token: 0x040001B5 RID: 437
			HARDWARE
		}

		// Token: 0x02000015 RID: 21
		[StructLayout(LayoutKind.Explicit)]
		private struct INPUTUNION
		{
			// Token: 0x040001B6 RID: 438
			[FieldOffset(0)]
			public InputHelper.MOUSEINPUT mi;

			// Token: 0x040001B7 RID: 439
			[FieldOffset(0)]
			public InputHelper.KEYBDINPUT ki;

			// Token: 0x040001B8 RID: 440
			[FieldOffset(0)]
			public InputHelper.HARDWAREINPUT hi;
		}

		// Token: 0x02000016 RID: 22
		private struct KEYBDINPUT
		{
			// Token: 0x040001B9 RID: 441
			public ushort wVk;

			// Token: 0x040001BA RID: 442
			public short wScan;

			// Token: 0x040001BB RID: 443
			public uint dwFlags;

			// Token: 0x040001BC RID: 444
			public int time;

			// Token: 0x040001BD RID: 445
			public IntPtr dwExtraInfo;
		}

		// Token: 0x02000017 RID: 23
		[Flags]
		private enum KEYEVENTF : uint
		{
			// Token: 0x040001BF RID: 447
			EXTENDEDKEY = 1U,
			// Token: 0x040001C0 RID: 448
			KEYUP = 2U,
			// Token: 0x040001C1 RID: 449
			UNICODE = 4U,
			// Token: 0x040001C2 RID: 450
			SCANCODE = 8U
		}

		// Token: 0x02000018 RID: 24
		private struct MOUSEINPUT
		{
			// Token: 0x040001C3 RID: 451
			public int dx;

			// Token: 0x040001C4 RID: 452
			public int dy;

			// Token: 0x040001C5 RID: 453
			public int mouseData;

			// Token: 0x040001C6 RID: 454
			public int dwFlags;

			// Token: 0x040001C7 RID: 455
			public int time;

			// Token: 0x040001C8 RID: 456
			public IntPtr dwExtraInfo;
		}
	}
}
