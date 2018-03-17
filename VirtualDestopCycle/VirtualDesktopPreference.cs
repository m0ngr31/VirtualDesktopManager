using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDesktop;

namespace VirtualDesktopManager
{
	public class VirtualDesktopPreference
	{
		public Guid VirtualDesktopId { get; set; }
		public string Name { get; set; }
		public string Wallpaper { get; set; }
	}
}
