   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   -    'OsnovnaSkolaUI.Views.AddZaposleniWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$  	Zaposleni��5   	   $��713.2��6   $	��566��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5	         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value �� Value �� 
TargetName �� Property��%�  &	        �� 5
   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      ���	#FF252323#��z��5      $ 5��6E   ._�5      �� $ PART_ContentHost��6   5       5      P� 5      	 � {�
 .  . �5      �� # � ��63   $ Bd��6u    � ���� 5      # � ��63    � ��5      P� 5      	 � ��$

 Auto��6+   . �5      ��  � ��$	 100��61   5      P� 5      	 � ��$

 Auto��6,   . �5      ��  � ��$ 20��62   5      5      5      .��5      � 
���   �.+�5   
   �� $��Center=�6+   $
��Left=�6O   $��66��6j   $��
137,18,0,0q�6v   $	��Top=�6�   $	��299��6�   $��28(�6�   $��Segoe UI)�6�   ���	#FFFBFB9F��6   �� *Naslov+6�   �� 5!   
   #��[  6   $
��Left=�6I   $��39��6d    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��227��6�   $��170,134,0,0q�6�   ���	#FF2E2E2E���	#FFA7A9A8$��22(�63  ��6�   �� *NoviZaposleni.ime+ �� UpdateSourceTrigger$ PropertyChanged=�63  �� 5"   
   #��[  6   $
��Left=�6I   $��39��6d   $��170,247,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��227��6�   ���	#FF2E2E2E���	#FFA7A9A8$��22(�67  ��6�   �� *NoviZaposleni.prezime+$ PropertyChanged=�67  �� 5#   
   #��[  6   $
��Left=�6J   $��39��6e   $��170,351,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��227��6�   ���	#FF2E2E2E���	#FFA7A9A8$��22(�67  ��6�   �� *NoviZaposleni.zvanje+$ PropertyChanged=�67  �� 5%   
   $
��Ime:��6   $
��Left=�6    $��40��6;   $��
170,89,0,0q�6G   $	��Top=�6[   $	��227��6s   $��Segoe UI)�6   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5&   
   $��Prezime:��6   $
��Left=�6$   $��42��6?   $��170,207,0,0q�6K   $	��Top=�6`   $	��227��6x   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5'   
   $��Zvanje:��6   $
��Left=�6#   $��36��6>   $��170,315,0,0q�6J   $	��Top=�6_   $	��227��6w   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5)   
   $��DODAJ��6   $
��Left=�6c   $	��Top=�6~   $	��221��6�   $��176,584,0,0q�6�   $��63��6�   $��Segoe UI)�6�   ���	#FFFBFB9F
������ 
�������$��36(�6  $
��Bold"�6+  y�6!   �� *	Visible+��6@   �� *AddUserCommand+6+  	� 5+   
   -   5        $��radioButtonU��5+       	� 	GroupName$ RadioButtonTip��6q   $��Učitelj��6�   ���	#FFFBFB9F$��Segoe UI)�6�   $
��Left=�6�   $��45��6�   $��137,534,0,0q�6�   $	��Top=�6  $��95��6  $��24(�6+  ���	#FFFBFB9F���	#FF1F5076 d� 	IsChecked 6*   �� *UciteljChecked+{�6O   �� *RBIsEnabled+6P  	� 5,   
   -   5        $��radioButtonN��5,      $ RadioButtonTip��6s   $��	Nastavnik��6�   ���	#FFFBFB9F$��Segoe UI)�6�   $
��Left=�6�   $��45��6�   $��298,534,0,0q�6�   $	��Top=�6  $	��138��6#  $��24(�60  ���	#FFFBFB9F���	#FF1F5076 6*   �� *NastavnikChecked+{�6Q   �� *RBIsEnabled+6U  �� 5-   
   $��Center=�6.   $
��Left=�6R   $��29��6m   $��137,178,0,0q�6y   $	��Top=�6�   $	��299��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *
ErrorIme+6�   �� 5.   
   $��Center=�62   $
��Left=�6W   $��29��6r   $��137,286,0,0q�6~   $	��Top=�6�   $	��299��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorPrezime+6�   �� 5/   
   $��Center=�61   $
��Left=�6V   $��30��6q   $��137,384,0,0q�6}   $	��Top=�6�   $	��299��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorZvanje+6�   �� 52   
   $��IZMENI��6   $
��Left=�6h   $	��Top=�6�   $	��221��6�   $��176,584,0,0q�6�   $��63��6�   $��Segoe UI)�6�   ���	#FFFBFB9F
������ 
�������$��36(�6"  $
��Bold"�60  y�6"   �� *
Visible2+��6B   �� *ChangeInfoCommand+60  �� 53   
   $��Korisničko ime:��6   $
��Left=�6+   $��36��6F   $��170,419,0,0q�6R   $	��Top=�6g   $	��227��6   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 54   
   #��[  6   $
��Left=�6J   $��39��6e   $��170,455,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��227��6  ���	#FF2E2E2E���	#FFA7A9A8$��22(�6>  ��6�   �� *NoviZaposleni.KorisnickoIme+$ PropertyChanged=�6>  �� 55   
   $��Center=�68   $
��Left=�6]   $��30��6x   $��137,499,0,0q�6�   $	��Top=�6�   $	��299��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorKorisnickoIme+6�   58      59      