   M S B A M L   `   `   `  ����Y  USchoolClubSpreadsheetPopulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SchoolClubSpreadsheetPopulatorSchoolClubSpreadsheetPopulator  5      ;    5SchoolClubSpreadsheetPopulator.ucGenerateSpreadsheets   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:SchoolClubSpreadsheetPopulator     5      X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5
      %  Xceed.Wpf.Toolkit.BusyIndicator  -   5           Name$  progressIndicator��5
         IsBusy .  $��12(�6C   .��5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� -   5         ��Name$ lblGenerationResult��5   o   $y�	Collapsed=�6    �� Padding$ 10q�6/   
��� � �$��WrapWithOverflow=�6O   $��50��6�   
�������$��Center=�6�   $��14(�6�   �� 5      -   5         ��Name$ btnOpenDirectory��5   3   $��Stretch=�6   $��View output��6l   $
��0,20q�6�   $��30��6�   $	��250��6�   $��5q�6�   ���	#FFCC0033
�������$��12(�6�   $y�Hidden=�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$
 0.25Q�6'   5      � 5      -   5         �Name$ spErrors��5      $y�Hidden=�6%   	 � ColumnDefinitions	 5      �� 5      $	��300 �6'   �� 5      $	��150 �6'   .+�5      �� -   5        
 ��Name$
 	lblErrors��5   5   $��0��6   $��0��6%   $��30��6H   ���	#FF574D4D$��14(�6k   $#��The following errors occured:��6y   �� 5      -   5        $ btnCopyErrors��5   T   $��Stretch=�6   $��0��67   $��1��6D   $��Copy to clipboard��6�   $��30��6�   $	��120��6�   $��5q�6�   
�������
���   �$��10(�6�    5        5      $
 0.25Q�6+   5      5      �� 5      -   5         ��Name$ lbErrors��5   +   $y�Hidden=�6   $
��Auto=�6=   $	��110��6m   $��12(�6z   $��0, 10, 0, 0q�6�   5      5       5!      