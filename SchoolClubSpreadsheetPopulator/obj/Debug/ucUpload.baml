   M S B A M L   `   `   `  ����Y  USchoolClubSpreadsheetPopulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SchoolClubSpreadsheetPopulatorSchoolClubSpreadsheetPopulator  5      -    'SchoolClubSpreadsheetPopulator.ucUpload   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:SchoolClubSpreadsheetPopulator     5      X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5	      %  Xceed.Wpf.Toolkit.BusyIndicator  -   5           Name$  progressIndicator��5	         IsBusy .  $��12(�6C   .��5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� -   5         ��Name$ spUpload��5   2   $ 
Horizontal=�6   $��Center=�6D   .+�5      �� $��Choose file to process��6   $��30��69   ���	#FFCC0033$��12(�6\   �� 5      -   5         ��Name$ txtFileName��5       �� TextWrapping$
 Wrap=�6/   $	��273��6C    � ToolTip$ Please choose a file��6O   $��30��6n   $��10(�6z   �� 5      -   5         ��Name$ 	btnBrowse��5      $��Browse��6D   $��80��6U   $	��0,0q�6`   $��30��6m   $��5q�6y   ���	#FFCC0033
�������$��12(�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Opacity$
	 0.25Q�6+   5      5      �� 5      -   5        $ 
spValidate��5      $ Vertical=�6-   $y�Hidden=�6D   $
��0,10q�6X   .+�5      �� -   5        $ spMonth��5   6   $ 
Horizontal=�6   $��Center=�6G   .+�5      �� $��Please select a month��6   $��30��6<   ���	#FFCC0033$��12(�6_   �� 5      -   5        
 ��Name$
 lbMonths��5      $��20��61   ���	#FFCC0033$��12(�6T   $	��150��6b   5      �� 5      -   5        $ btnValidate��5      $��Validate file��6H   $	��250��6`   $
��0,20q�6l   $��30��6z   $��5q�6�   ���	#FFCC0033
�������$��12(�6�    5        5      $
	 0.25Q�6+   5      5       �� 5#      -	   5        $ spResult��5#      $ Vertical=�6+   $y�Hidden=�6B   .+�5$      �� -
   5         ��Name$ lblValidationResult��5$   \    �� Padding$ 10q�6   
��� � �$��WrapWithOverflow=�6<   $��50��6y   
�������$��Center=�6�   $��14(�6�   $y�	Collapsed=�6�   � 5%      -   5         �Name$ spErrors��5%      $y�	Collapsed=�6)   $��Center=�6@   $	��0,5q�6]    � ColumnDefinitions 5&      �� 5'      $	��300 �6+   �� 5(      $	��150 �6+   .+�5*      �� -   5         ��Name$ 	lblErrors��5*   9   $��0��6   $��0��6)   $��30��6L   ���	#FF574D4D$��12(�6o   $$��However there were some errors��6}   $��Center=�6�   �� 5+      -   5        $ btnCopyErrors��5+   X   $��Stretch=�6   $��0��6;   $��1��6H   $��Copy to clipboard��6�   $��30��6�   $	��120��6�   $��5q�6�   
�������
���   �$��10(�6�    5,        5-      $
	 0.25Q�6/   5/      50      �� 51      -   5         ��Name$ lbErrors��51      $y�	Collapsed=�6,   $
��Auto=�6C   $	��110��6s   $��12(�6�   $��0, 10, 0, 0q�6�   �� 52      -   5        $ 
btnProceed��52      $��Generate spreadsheets��6Q   $
��0,20q�6q   $��30��6   $	��250��6�   $��5q�6�   ���	#FFCC0033
�������$��12(�6�    53        54      $
	 0.25Q�6+   56      57      58      59      5:      