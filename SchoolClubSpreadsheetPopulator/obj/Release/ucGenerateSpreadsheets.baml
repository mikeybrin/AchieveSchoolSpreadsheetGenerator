   M S B A M L   `   `   `  ���� Y  USchoolClubSpreadsheetPopulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SchoolClubSpreadsheetPopulatorSchoolClubSpreadsheetPopulator  ;    5SchoolClubSpreadsheetPopulator.ucGenerateSpreadsheets   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:SchoolClubSpreadsheetPopulator     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��%  Xceed.Wpf.Toolkit.BusyIndicator  -      Name$  progressIndicator��   IsBusy .  $��12(�.����  �� Orientation$ Vertical=�.+��� -    ��Name$ lblGenerationResult��$y�	Collapsed=� �� Padding$ 10q�
��� � �$��WrapWithOverflow=�$��50��
�������$��Center=�$��14(��� -    ��Name$ btnOpenDirectory��$��Stretch=�$��View output��$
��0,20q�$��30��$	��250��$��5q����	#FFCC0033
�������$��12(�$y�Hidden=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$
 0.25Q�� -    �Name$ spErrors��$y�Hidden=�	 � ColumnDefinitions	 �� $	��300 ��� $	��150 �.+��� -   
 ��Name$
 	lblErrors��$��0��$��0��$��30�����	#FF574D4D$��14(�$#��The following errors occured:���� -   $ btnCopyErrors��$��Stretch=�$��0��$��1��$��Copy to clipboard��$��30��$	��120��$��5q�
�������
���   �$��10(�   $
 0.25Q��� -    ��Name$ lbErrors��$y�Hidden=�$
��Auto=�$	��110��$��12(�$��0, 10, 0, 0q�