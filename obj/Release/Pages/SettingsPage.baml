   M S B A M L   `   `   `  ���� D  @Nexus 2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Nexus_2._0.PagesNexus_2._0.Pages  #    Nexus_2._0.Pages.SettingsPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:Nexus_2._0.Pages        BackgroundColor  N� 
Background#  �    N� Title$ MultiplayerPage�� � 	Resources   CustomButtonStyle �� 
TargetType �� Property  ButtonBackground �� Value  ButtonBorderBrush  ButtonForeground �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName  HoverBackground  PressedBackground  CustomTextBoxStyle ��Name��%�  &	       &	 �    �� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 20(���  � ��$ 	20,0,20,0q���  � ��$
 10,5q���  �@�Cursor$
 Hand����  � ��$ 2q���  � �� �� " ��.R��� $ border��#��z��#��z��$��0q�$ 5��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# �   � ��P� 
 � �� . . ��� $ border��# �   � ���� " ��.���  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 20(���  � ��$ 	20,0,20,0q���  � ��$
 10,5q���  � ��$ 2q���  �@�Cursor$ IBeam����  � �� �� " ��.R��� $ border��#��z��#��z��$��0q�$ 5��._��� $ PART_ContentHost��$��Center=�	 P� 
 �@J�IsMouseOver . . ��� $ border��# �   � ��P� 
 �@J�IsKeyboardFocused . . ��� $ border��# �   � ��.��� $��0,0,0,0q� � RowDefinitions �� .+��� -    ��Name$ Launch��#��[ $��440,522,155,30q�$
��Save���� $ 10�� �� Padding$ 5q�$��25,0,25,493q�����  �� ImageSource$8 2/Pages/wp7885721-fortnite-landscape-wallpapers.png�� j� Stretch$ UniformToFill=� j� TileMode$ FlipX=�._��� .+��� $��This is��$��56(�  HeaderTextColor#���  $
��Left=�$��72�� �� Left$	 382��$	��Top=�$	��175��$
��Bold"�$��Italic$�
 �� Top$ 10���� $��Settings��$��56(�#���  $��84��$	 561��$	��226��$
��Left=�$	��Top=�$
��Bold"�$��Italic$�$ 10���� -   $ Launch_Copy��#��[ $��132,521,822,30q�$��Select Theme���� -    ��Name$ EmailBox��$
��Left=�$��
70,224,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��545��$��52��$��24(�#��[ �� -   $ PasswordBox��$
��Left=�$��638,224,0,0q�$
 Wrap=�$	��Top=�$	��527��$��52��$��24(�#��[ �� -   $ GamePathBox��$��Center=�$��	0,376,0,0q�$
 Wrap=�$	��Top=�$
��1102��$��52��$��24(�#��[ �� $��
Game Path:��$��25(�$	��176��$
��Left=�$��66,329,0,232q�#���  �� $��	Password:��$��25(�$��42��$	��176��$
��Left=�$	��Top=�$��630,182,0,0q�#���  �� $��Email:��$��25(�$��42��$	��176��$
��Left=�$	��Top=�$��
66,182,0,0q�#���  