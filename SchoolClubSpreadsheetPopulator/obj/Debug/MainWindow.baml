   M S B A M L   `   `   `  ����Y  USchoolClubSpreadsheetPopulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SchoolClubSpreadsheetPopulatorSchoolClubSpreadsheetPopulator  5   	   /    )SchoolClubSpreadsheetPopulator.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:SchoolClubSpreadsheetPopulator     5   	     � 
ResizeMode$  	CanResize=�5   	   $	��620��5	   	   $	��725��6   $��	Helvetica)�5
   	   $��18(�5   	   ���	#FFCC0033$
��Bold"�5   	   ���#ffffff � AllowsTransparency .   � WindowStartupLocation$ CenterScreen=�5   	   .��5      � -   5         �Name$ gIntro��5       � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��350 �6   �� 5      $��30 �6   �� 5      $��70 �6   .+�5   
   �� -   5         ��Name$ imgLogo��5   -   $��0��6   $��0��6   $��Images/photo.jpg��6>   $��Stretch=�6o    J� OpacityMask 6X   Z� 6o   �� 5   
   -   5         ��Name$ 	ccWelcome��5      $��1��6,   $��0��69   $y�Visible=�6I   $��40q�6^   6l   �� 5   
   -   5        $ ccUpload��5      $��1��6+   $��0��68   $y�Hidden=�6H   $��40q�6\   6j   �� 5   
   -   5        $ 
ccGenerate��5      $��1��6-   $��0��6:   $y�Hidden=�6J   $��40q�6^   6l   �� 5   
   -   5         ��Name$ btnStartOver��5   O   $��12(�6   $y�Hidden=�6   $��2��6e   $��Cancel��6r   $��Center=�6�   $��5q�6�   $	��250��6�   
�������
���   �	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   Opacity$

 0.25Q�6#   5!      �� 5"   
   $��3��6   $��0��6   $��Center=�6-   $��Center=�6Q   $��12(�6s   $��Centaur)�6�   $��38��6�   ���	#FF303030
�������$f��`© 2016 The Prince's Trust - registered charity: England and Wales 1079675 and Scotland SC041198��6�   5#      5$      