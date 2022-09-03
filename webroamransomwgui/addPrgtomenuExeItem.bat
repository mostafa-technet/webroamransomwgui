reg add "HKEY_CLASSES_ROOT\SystemFileAssociations\.exe\shell\Trust This Program" /f /v "MultiSelectModel" /d "Player"
reg add "HKEY_CLASSES_ROOT\SystemFileAssociations\.exe\shell\Trust This Program\command" /f /ve /t REG_EXPAND_SZ /d "C:\Users\myOS\Desktop\scanner\filter\x64\Release\gui\webroamransomwgui.exe %1,*"
