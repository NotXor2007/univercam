import wx
from sys import exit as Exit
import const

class Menus(wx.MenuBar):

    def __init__(self):
        super(Menus, self).__init__()
        self.fileMenu = wx.Menu()
        self.aboutMenu = wx.Menu()
        self.exitItem = wx.MenuItem(self.fileMenu, wx.ID_EXIT, "Exit\tCtrl+E", "quit program")
        self.exitItem.SetBitmap(wx.Bitmap(const.exit_icon[0]))
        self.fileMenu.Append(self.exitItem)
        self.Bind(wx.EVT_MENU, self.QuitEvent)
        self.Append(self.fileMenu, "File")
        self.Append(self.aboutMenu, "About")
    
    def QuitEvent(self, event):
        self.Close()
        Exit(0)
    
    def ShowMenus(self, Frame):
        Frame.SetMenuBar(self)
