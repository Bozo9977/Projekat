   M S B A M L   `   `   `  ����I  EOsnovnaSkolaUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OsnovnaSkolaUI.ViewsOsnovnaSkolaUI.Views  5   	   ,    &OsnovnaSkolaUI.Views.AddUcionicaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OsnovnaSkolaUI.Views     5   	     � Title$  Nova učionica��5   	   $	��505��6   $	��490��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � 	Resources 5
         FocusTextBox �� 
TargetType �� Triggers �� Binding �� ElementName �� Path	 �� Value
 �� Property �� Value��%�   &	        �� 5   
   " �6%    5      �� 5       6   �� $ 
textBoxIme��$ 	IsVisible�	 True6Y   .a�5      �� 
 �@+�FocusedElement 6D   �� $ textBoxPrezime��5      5      5      .��5      � -   5         �Name$ UcionicaGrid��5      
���   �$��0,0,0,-1q�64   #��[  6F   .+�5   
   �� $��	Učionica��6   $��Center=�6#   $��66��6G   $��
21,10,23,0q�6S   $	��Top=�6g   $��26(�6�   $��Segoe UI)�6�   ���	#FFFBFB9F6�   �� 5   
   $��Naziv učionice:��6   $��Center=�6*   $
��Left=�6N   $��34��6i   $��
113,93,0,0q�6u   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   �� 5   
   -   5         ��Name$ NazivBox��5      $
��Left=�6$   $
��Left=�6?   $��Center=�6a   $��Khmer UI)�6�   $��20(�6�    �� TextWrapping$
 Wrap=�6�   $	��244��6  $��113,137,0,0q�6  ���	#FF2E2E2E���	#FF282829���	#FFFBFB9F$��39��6l  $	��Top=�6x  ��6�   �� *NovaUcionica.naziv+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   J� InputBindings 5      �� 5      
 �� Key$ Enter��6D    �� Command 6   �� *AddUcionicaCommand+6D   .��5   %   5      �� 5   
   -   5        $��imeError��5   T   $��Center=�6d   $��Center=�6�   $
��Left=�6�   $��34��6�   $��
21,176,0,0q�6�   $	��Top=�6�   $	��440��6�   $��Segoe UI)�6	  
���  ��$��16(�60  ��6   �� *
NazivError+$ PropertyChanged=�60  �� 5    
   $��Smešta učenika:��6   $��Center=�6*   $
��Left=�6N   $��38��6i   $��113,218,0,0q�6u   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   �� 5!   
   -   5        $ BroUcenikaBox��5!      $��20(�6)   $
��Left=�6b   ���	#FF2E2E2E$��1q�6�   ���	#FF282829$
��Left=�6�   $��Center=�6�   $��34��6  $	��243��6  ���	#FFFBFB9F$��114,261,0,169q�63  ��67   �� *NovaUcionica.broj_ucenika+.��6J   5"      �� 5#      $ Enter��6D    6   �� *AddUcionicaCommand+6D   .��5$   %   5%      �� 5(   
   -   5        $��prezimeError��5(   S   $��Center=�6g   $��Center=�6�   $
��Left=�6�   $��34��6�   $��
21,323,0,0q�6�   $	��Top=�6�   $	��440��6   $��Segoe UI)�6  
���  ��$��16(�63  ��6   �� *	BrojError+$ PropertyChanged=�63  �� 5*   
    �� 	IsDefault . $
��Left=�6l   $��24(�6�   $	��Top=�6�   $	��130��6�   $��168,382,0,0q�6�   $��48��6�    J� RenderTransformOrigin$ 0.769,0.381&�6�   $��Segoe UI)�6   
������ 
����������	#FFFBFB9F$
��Bold"�6Z  ��6   �� *ButtonContent+��6E   �� *AddUcionicaCommand+6Z  5,      5-      