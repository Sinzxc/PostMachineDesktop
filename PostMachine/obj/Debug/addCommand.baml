   M S B A M L   `   `   `  ����F  BPostMachine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PostMachinePostMachine  5   	       PostMachine.addCommand   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PostMachine     5   	     � Title$)  #Добавление команды��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b   ���	#FF12141F � WindowStyle$
 None=�6�   .��5	      � .+�5
   
   �� $%��Добавить команду��6   $��Center=�6+   $��0,21,0,0q�6H   $	��Top=�6Z   
�������$��20(�6�   �� 5   
   $#��Введите команду��6   $��Center=�6*   $��	0,101,0,0q�6G   $	��Top=�6Z   
�������6r   �� 5   
   $5��/Укажите ссылку на команду��6   $��Center=�64   $	��Top=�6Q   
�������$��	0,179,0,0q�6|   �� 5   
   -   5         ��Name$ 
link2label��5      $B��<Укажите вторую ссылку на команду��6$   $��Center=�6O   $	��Top=�6l   
�������$��	0,272,0,0q�6�   �� 5   
   -   5        $��Создать��5      $
��Left=�6#   $��296,372,0,0q�6>   $	��Top=�6S   $��94��6k   ���	#FF202335
����������	#007070706�   �� 5   
   -   5        $��
Назад��5      $
��Left=�6!   $��400,372,0,0q�6<   $	��Top=�6Q   $��94��6i   ���	#FF202335
����������	#007070706�   �� 5   
   -   5         ��Name$ 	linklabel��5      $��Center=�6%   $��	0,230,0,0q�6B    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��120��6�   6�   �� 5   
   -   5        $ 
link2input��5      $��Center=�6&   $��	0,320,0,0q�6C   $
 Wrap=�6V   $	��Top=�6j   $	��120��6�   6�   �� 5   
   -   5        $��Center=�5      $��	0,141,0,0q�60   $	��Top=�6C   $	��120��6[   .@�5      �� $	��←��6   �� 5      $	��→��6   �� 5      $��V��6   �� 5      $��X��6   �� 5      $��?��6   �� 5      $��!��6   5      5      5      