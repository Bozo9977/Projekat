   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   *    $OsnovnaSkolaUI.Views.AddDomaciWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$  AddDomaciWindow��5   	   $��683.461��6!   $	��566��62    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T    � 	Resources 5	         TextBoxBaseControlTemplate �� 
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
 Wrap=�6p   $	��Top=�6�   $	��464��6�   $��
55,129,0,0q�6�   ���	#FF2E2E2E���	#FFA7A9A8$��22(�63  ��6�   �� *NoviDomaci.zadatak+ �� UpdateSourceTrigger$ PropertyChanged=�63  (  "System.Windows.Controls.DatePicker  5"   
   $��55,239,41,355q�6G      SelectedDate 6   �� *NoviDomaci.dan_zadavanja+6`     5#   
   $��55,340,41,256q�6E    6   �� *NoviDomaci.dan_predaje+6^   �� 5$   
   $��Zadatak:��6   $
��Left=�6$   $��40��6?   $��
164,89,0,0q�6K   $	��Top=�6_   $	��227��6w   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5%   
   $��Dan zadavanja:��6   $
��Left=�6*   $��42��6E   $��164,197,0,0q�6Q   $	��Top=�6f   $	��227��6~   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5&   
   $��Dan predaje:��6   $
��Left=�6(   $��36��6C   $��164,299,0,0q�6O   $	��Top=�6d   $	��227��6|   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5'   
   $
��Left=�6Y   $	��Top=�6t   $	��221��6�   $��170,568,0,0q�6�   $��45��6�   $��Segoe UI)�6�   ���	#FFFBFB9F
������ 
�������$��36(�6  $
��Bold"�6!  ��6   �� *ButtonContent+��64   �� *AddDomaciCommand+6!  �� 5(   
   $
��Left=�62   $��29��6M   $��
55,168,0,0q�6Y   $	��Top=�6m   $	��464��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorZadatak+6�   �� 5)   
   $
��Left=�69   $��29��6T   $��
55,270,0,0q�6`   $	��Top=�6t   $	��464��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorDatumZadavanja+6�   �� 5*   
   $
��Left=�67   $��30��6R   $��
55,368,0,0q�6^   $	��Top=�6r   $	��464��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorDatumPredaje+6�   &   System.Windows.Controls.DataGrid  5,   
   $
��Left=�6g   $	��107��6�   $��
10,403,0,0q�6�   $	��Top=�6�   $	��540��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .     
IsReadOnly . ��6   �� *
Predmeti+$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 6�   �� *SelectedPredmet+   Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Razred��6%    �� TextAlignment$ Center=�65      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6V   �� *razred+   ElementStyle 51      �� 52       �� 
TargetType" ��6    .�53      ��  � ��$
 Wrap=�6=   �� 54       � ��$ Center=�6D   �� 55       � ��$ Center=�6B   56      58        5;      $ Naziv��6%   $ Center=�64    .  6U   �� *naziv+ 5<      �� 5=      " ��6    .�5>      ��  � ��$
 Wrap=�6=   �� 5?       � ��$ Center=�6D   �� 5@       � ��$ Center=�6B   5A      5C        5E      $ Razred��6%   $ Center=�65    .  6V   �� *broj_oblasti+ 5F      �� 5G      " ��6    .�5H      ��  � ��$
 Wrap=�6=   �� 5I       � ��$ Center=�6D   �� 5J       � ��$ Center=�6B   5K      5M      5a      �� 5c   
   $��OBRIŠI��6    �� 	IsDefault . $
��Left=�6�   $��24(�6�   $	��Top=�6�   $	��221��6�   $��170,515,0,0q�6�   $��48��6�    J� RenderTransformOrigin$ 0.769,0.381&�6�   $��Segoe UI)�6  
������ 
����������	#FFFBFB9F$
��Bold"�6q  y�6#   �� *DeletionEnabled+��6[   �� *DeleteDomaciCommand+6q  5e      5f      