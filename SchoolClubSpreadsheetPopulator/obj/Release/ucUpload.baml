   M S B A M L   `   `   `  ���� Y  USchoolClubSpreadsheetPopulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SchoolClubSpreadsheetPopulatorSchoolClubSpreadsheetPopulator  -    'SchoolClubSpreadsheetPopulator.ucUpload   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:SchoolClubSpreadsheetPopulator     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��%  Xceed.Wpf.Toolkit.BusyIndicator  -      Name$  progressIndicator��   IsBusy .  $��12(�.����  �� Orientation$ Vertical=�.+��� -    ��Name$ spUpload��$ 
Horizontal=�$��Center=�.+��� $��Choose file to process��$��30�����	#FFCC0033$��12(��� -    ��Name$ txtFileName�� �� TextWrapping$
 Wrap=�$	��273�� � ToolTip$ Please choose a file��$��30��$��10(��� -    ��Name$ 	btnBrowse��$��Browse��$��80��$	��0,0q�$��30��$��5q����	#FFCC0033
�������$��12(� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Opacity$
	 0.25Q��� -   $ 
spValidate��$ Vertical=�$y�Hidden=�$
��0,10q�.+��� -   $ spMonth��$ 
Horizontal=�$��Center=�.+��� $��Please select a month��$��30�����	#FFCC0033$��12(��� -   
 ��Name$
 lbMonths��$��20�����	#FFCC0033$��12(�$	��150���� -   $ btnValidate��$��Validate file��$	��250��$
��0,20q�$��30��$��5q����	#FFCC0033
�������$��12(�   $
	 0.25Q��� -	   $ spResult��$ Vertical=�$y�Hidden=�.+��� -
    ��Name$ lblValidationResult�� �� Padding$ 10q�
��� � �$��WrapWithOverflow=�$��50��
�������$��Center=�$��14(�$y�	Collapsed=�� -    �Name$ spErrors��$y�	Collapsed=�$��Center=�$	��0,5q� � ColumnDefinitions �� $	��300 ��� $	��150 �.+��� -    ��Name$ 	lblErrors��$��0��$��0��$��30�����	#FF574D4D$��12(�$$��However there were some errors��$��Center=��� -   $ btnCopyErrors��$��Stretch=�$��0��$��1��$��Copy to clipboard��$��30��$	��120��$��5q�
�������
���   �$��10(�   $
	 0.25Q��� -    ��Name$ lbErrors��$y�	Collapsed=�$
��Auto=�$	��110��$��12(�$��0, 10, 0, 0q��� -   $ 
btnProceed��$��Generate spreadsheets��$
��0,20q�$��30��$	��250��$��5q����	#FFCC0033
�������$��12(�   $
	 0.25Q�