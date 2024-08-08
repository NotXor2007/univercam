from onvif import ONVIFCamera #a module for working with onvif camera through internet
import wx #a wrapper for wxwidgets c++ gui lib(requires redist 14.2 and later)
import ctypes #module for working with low-level stuff
from widgets import menu
from sys import exit as Exit
import const

class Main(wx.Frame):

    def __init__(self, *args, **kwargs):
        super(Main, self).__init__(*args, **kwargs)
        menu.Menus().ShowMenus(self)
        self.toolbar = self.CreateToolBar()
        self.ID_ONVIF = wx.NewId()
        self.exittool = self.toolbar.AddTool(wx.ID_EXIT, 'Exit', wx.Bitmap(const.exit_icon[3]))
        self.onviftool = self.toolbar.AddTool(self.ID_ONVIF, 'Onvif', wx.ArtProvider.GetBitmap(wx.ART_MISSING_IMAGE))
        self.toolbar.Realize() #show it
        self.Bind(wx.EVT_TOOL, self.ToolEvent, self.exittool)
        self.Bind(wx.EVT_TOOL, self.ToolEvent, self.onviftool)
        self.Center()
        self.Show(True)
    
    def ToolEvent(self, event):
        exitid = event.GetId()
        if exitid == self.exittool.GetId(): self.Close();Exit(0)
        elif exitid == self.onviftool.GetId():
            onvif = __import__("onvif") #dynamic import to save memory
            result = onvif.Onvif.connect("")
        
    def setIcon(self):
        #icon = wx.Icon('.\\assets\\exit_button_s1.png', wx.BITMAP_TYPE_ICO)
        #self.SetIcon(icon)
        pass

#entry-point
if __name__ == "__main__":
    app = wx.App()
    Main(None, title = "Univercam v0.1", style = const.window_style, size = const.window_size)
    app.MainLoop()
    Exit(0)

#requires .net 4 & visual c++