   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   *    $OsnovnaSkolaUI.Views.PrisustvaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$  Evidentiraj prisustvo��5   	   $	��450��6'   $��711.5��64    � WindowStartupLocation$ CenterScreen=�6B   .��5	      � 
���   �.+�5
   
   �� $��Evidencija prisustva��6   $��Center=�6/   $��66��6S   $��
21,10,23,0q�6_   $	��Top=�6s   $��26(�6�   $��Segoe UI)�6�   ���	#FFFBFB9F6�   &   System.Windows.Controls.DataGrid  5   
      SelectionMode$ Extended=�6f      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .     
IsReadOnly . $��
0,95,0,107q�6�   ��6   �� *	Ucenici+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 6   �� *SelectedUcenik+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 Ime��6%    �� TextAlignment$ Center=�62      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *ime+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   �� 5       � ��$ Center=�6D   �� 5       � ��$ Center=�6B   5      5        5!      $
 Prezime��6%   $ Center=�66    .  6W   �� *	prezime+ 5"      �� 5#      " ��6    .�5$      ��  � ��$
 Wrap=�6=   �� 5%       � ��$ Center=�6D   �� 5&       � ��$ Center=�6B   5'      5)      4  .System.Windows.Controls.DataGridTemplateColumn  5+      $
 Prisustvovao��6)      CellTemplate 5,      �� 5-      .R�5.      �� ��6%   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType"   �� Path$( "DataContext.UcenikPrisustvoCommand���6�   �� .��6�   Prisustvovao6�   5/      51      54      �� 56   
   $��EVIDENTIRAJ��6   $��18(�6W   
������ 
��� ���$��260,369,290,0q�6�   $	��Top=�6�   $��40��6�   ��6'   �� *EvidentirajPrisustvoCommand+6�   5:      5;      