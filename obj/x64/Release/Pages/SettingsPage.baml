   M S B A M L   `   `   `  ���� D  @Nexus 2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Nexus_2._0.PagesNexus_2._0.Pages  #    Nexus_2._0.Pages.SettingsPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:Nexus_2._0.Pages        BackgroundColor  N� 
Background#  �    N� Title$ MultiplayerPage�� � 	Resources   CustomButtonStyle �� 
TargetType �� Property  ButtonBackground �� Value  ButtonBorderBrush  ButtonForeground �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName  HoverBackground  PressedBackground  CustomTextBoxStyle ��Name��%�  &	       &	 �    �� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 20(���  � ��$ 	20,0,20,0q���  � ��$
 10,5q���  �@�Cursor$
 Hand����  � ��$ 2q���  � �� �� " ��.R��� $ border��#��z��#��z��$��0q�$ 10��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# �   � ��P� 
 � �� . . ��� $ border��# �   � ���� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 20(���  � ��$ 	20,0,20,0q���  � ��$
 10,5q���  � ��$ 2q���  �@�Cursor$ IBeam����  � �� �� " ��.R��� $ border��#��z��#��z��$��0q�$ 10��._��� $ PART_ContentHost��$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# �   � ��P� 
 �@J�IsKeyboardFocused . . ��� $ border��# �   � ��.��� .+��� -    ��Name$ Launch��#��[ $��440,516,155,36q�$
��Save���� $ 10�� �� Padding$ 5q�$��25,30,25,463q�����  �� ImageSource$8 2/Pages/wp7885721-fortnite-landscape-wallpapers.png�� j� Stretch$ UniformToFill=� j� TileMode$ FlipX=�._��� .+��� $��This is��$��56(�  HeaderTextColor#���  $
��Left=�$��72�� �� Left$	 382��$	��Top=�$	��175��$
��Bold"�$��Italic$�
 �� Top$ 10���� $��Settings��$��56(�#���  $��84��$	 561��$	��226��$
��Left=�$	��Top=�$
��Bold"�$��Italic$�$ 10���� -    ��Name$ EmailBox��#��[ $
��Left=�$��
84,196,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��653��$��51��$��Email��.�� � ToolTip _� $��Please enter a valid URL.��.���� -   $ GamePathBox��#��[ $
��Left=�$��84,0,0,0q�$
 Wrap=�$��Center=�$
��1051��$��51��$��	Game Path��.�� _� $��Please enter a valid URL.��.���� -   $ PasswordBox��#��[ $
��Left=�$��762,196,0,0q�$
 Wrap=�$	��Top=�$	��373��$��51��$��Password��.�� _� $��Please enter a valid URL.��.���� -   $ Launch_Copy��#��[ $��132,516,822,36q�$��Select Theme��