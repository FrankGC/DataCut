   M S B A M L   `   `   `  ����B  >Datacut, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DatacutDatacut  5          Datacut.pg_cortes   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      !localclr-namespace:Datacut  5        N� Title$  	pg_cortes��5
         
background N� 
Background# [  6   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $��1* �6   .+�5   
   � $��1��6   $��2��6    5      �� 5      �� 5      �� 5      �� 5      .+�5      (� .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5       �� $��50��6   $��imagenes/tt.png��6*   �� 5!      -   5         ��Name$ 
t_trabajos��5!   K   $��1��6    $��Center=�60   
�������6_   5"      5#      (� 5$      $��1��6   .��5%      �� $ 
Horizontal=�6   .+�5&      �� $��50��6   $��imagenes/pay.png��6*   �� 5'      -   5        $ 
t_comision��5'       $��Center=�64   
�������6O   5(      5)      (� 5*      $��2��6   .��5+      �� $ 
Horizontal=�6   .+�5,      �� $��50��6   $��imagenes/ventas.png��6*   �� 5-      -   5        $ t_ventas��5-       $��Center=�62   
�������6M   5.      5/      (� 50      $��3��6   .��51      �� $ 
Horizontal=�6   .+�52      �� $��50��6   $��imagenes/total.png��6*   �� 53      -   5        $ t_ganancias��53       $��Center=�65   
�������6P   54      55      57      � 58   
   $��1��6    59      �� 5:      $��1* �6    �� 5;      $
��0.5* �6    �� 5<      $��1* �6    .+�5>      �� -   5         ��Name$ 	btn_corte��5>        bt_style#��[ 6(   .��5?      (� .��5@      �� .+�5A      �� $��/imagenes/cortes.png��6    6@   �� 5B      $��Corte��6$   
�������$	��100(�6D   $��10q�6S   5C      5D      5E      �� 5G      -   5        $ 
bt_guardar��5G      $��2��6)   #��[ 66   .��5H      (� .��5I      �� .+�5J      �� $��/imagenes/save.png��6    6>   �� 5K      $��Exportar a exel��6$   
�������$	��100(�6N   $��10q�6]   5L      5M      5N      5O      � 5P   
   $��1��6   $��1��6   $��2��6-   $��10q�6A    5Q      �� 5R      $
��0.5* �6    �� 5S      $	��10* �6     5U      �� 5V      �� 5W      .+�5Y      (� .��5Z      �� $��Trabajos realizados��6   
�������$��Center=�6J   5[      (� 5\      $��1��6   .��5]      �� $��Productos vendidos��6   
�������$��Center=�6J   5^      &   System.Windows.Controls.DataGrid  5_      -   5          Name$ lista_productos��5_      $��1��60   $��1��6=   
������� J� Opacity$	 0.6Q�6`   	   
IsReadOnly	 . 
������ $��5q�6�   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   $��16(�6�     AzureDataGrid#��[ 6�   6
    5`      -   5        $ lista_trabajos��5`      $��1��6/   
�������$	 0.6Q�6O   	 . 
������ $��5q�6�   $
 * 6�   $��16(�6�   #��[ 6�   6�   5a      +  %MahApps.Metro.Controls.FlyoutsControl  5b   
   $��2��6"   $��2��62   .@�5c      #  MahApps.Metro.Controls.Flyout  -	   5          Name$ 	fly_corte��5c         Position$ Right=�61   $��Corte de caja��6B   ���#6d8fc6   IsOpen .  .��5d      (� $��5q�6   .��5e      �� .+�5f      �� $	��130��6%   $��Dia de inicio��64   +  %MahApps.Metro.Controls.DateTimePicker  5g      -
   5          Name$ 	tp_inicio��5g   2   $	��130��6E   �� 5h      $	��130��6%   $��	Dia final��64     5i      -   5        $��tp_fin��5i   B   $	��130��63   6B   �� 5j      $ 
Horizontal=�6%   $	��130��6?   .+�5k      �� -   5        $ bt_corte_cancelar��5k   %   
���   �$��25��6S   
�������$	 0.8Q�6|   $��3q�6�   #��[ 6�   $��Cancelar��6�   6�   �� 5l      -   5        $ bt_corte_ok��5l   &   
���   �$��	Confirmar��6N   $��25��6b   $��1��6q   
�������$	 0.8Q�6�   $��3q�6�   #��[ 6�   6�   5m      5n      5o      5p      5q        5r   
   $��2��6#   $��2��63   .@�5s        -   5        $ fly_trabajos��5s      $ Right=�64   $��Trabajos realizados��6E   ���#6d8fc6 .  .��5t      �  5u      �� 5v      $��1* �6(   �� 5w      $��1* �6(   �� 5x      $��8* �6(   �� 5y      $��1* �6(   �� 5z      $��1* �6(   .+�5|      (� $��10q�6   .��5}      �� -   5        $ lista_nombre��5}   $   5~      (� 5      $��1��6   $��10q�6+   .��5�      �� -   5        $ lista_count��5�   $   $	��130��69   5�        5�      -   5        $ lista��5�   P   $��2��6   $��Center=�6,   $
 * 6_   6o   (� 5�      $��3��6   $��10q�6+   .��5�      �� -   5        $ lista_comision��5�   $   $	��130��6<   5�      (� 5�      $��4��6   $��10q�6+   .��5�      �� -   5        $ lista_total��5�   $   $	��130��69   5�      5�      5�      5�      �� 5�   
   -   5        $ btn_back��5�   !   $��0��6   
������ 
������ .��5�      (� .��5�      �� $��imagenes/undo.png��6   5�      5�      5�      5�      