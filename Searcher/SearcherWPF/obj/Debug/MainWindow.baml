   M S B A M L   `   `   `  ����  SearcherWPF    SearcherWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  Searcher (:��5   	   $	��400��6   $	��600��6*   .��5      ]� ��. .+�5   
   o� $	��Top=�6   $
��Left=�6$   .@�5      m� $��_File��6   m� 5	      $��_Edit��6   .@�5
      m�  m� Command$ ApplicationCommands.Copy��6   m� 5      $ ApplicationCommands.Cut��6   m� 5      $ ApplicationCommands.Paste��6   m� 5      $��Configuration��6   5      m� 5      $��_About��6   5      �� 5   
   $��Bottom=�6   .@�5      �� $
��Left=�6   .��5      �� -   5         ��Name$ 	StatusBar��5      $��Ready��6/   5      �� 5      $��Right=�6   .��5      �� -   5        $ ThreadCount��5      $��Threads in process: ��61   5      5      ]� 5   
   $	��Top=�6   ��. .+�5      �� $
��Left=�6   $��	Site List��6*   5      ]� 5   
   $��Bottom=�6   ��. .+�5      �� $
��Left=�6   $��Filters��6*   �� 5      -   5         ��Name$ 
SaveFilter��5   ,   $��Right=�6   $
��Save��6@   �� 5       
�������6   5!      � 5#   
    � ColumnDefinitions 5$      �� 5%      $��* �6#   $	��250��6-   $	��100��6<   �� 5&      $
��auto �6#   �� 5'      $��2.75* �6#   .+�5)      �� -   5         ��Name$ SitesListView��5)      $��0��6.   �� 5*      $��0��6   $��1��6(   $��5��68   $��Stretch=�6B   $��Center=�6^   �� 5+      -   5        $ TopicsListView��5+      $��2��6/    �� View 5,      �� 5-      .P�5.      �� $��Title��6)   �� 5/      $
��Link��6)   50      52      53      54      55      