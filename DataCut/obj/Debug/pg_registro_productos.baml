   M S B A M L   `   `   `  ����B  >Datacut, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DatacutDatacut  5      #    Datacut.pg_registro_productos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      !localclr-namespace:Datacut  5        N� Title$  pg_registro_productos��5
         
background N� 
Background# [  6%   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��2* �6   .+�5   
   � $��1��6    5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    .+�5      �� -   5         ��Name$ btn_add��5        bt_style#��[ 6&   .��5      (� .��5      �� .+�5      �� $��/imagenes/add_product.png��6    6E   �� 5       $��Agregar producto��6$   
�������$	��100(�6O   $��10q�6^   5!      5"      5#      �� 5$      -   5        $ bt_edit��5$      $��1��6&   #��[ 63   .��5%      (� .��5&      �� .+�5'      �� $ ��/imagenes/edit_product.png��6    6F   �� 5(      $��Editar producto��6$   
�������$	��100(�6N   $��10q�6]   5)      5*      5+      �� 5,      -   5        $ 	bt_delete��5,      $��2��6(   #��[ 65   .��5-      (� .��5.      �� .+�5/      �� $��/imagenes/trash.png��6    6?   �� 50      $��Eliminar producto��6$   
�������$	��100(�6P   $��10q�6_   51      52      53      54      � 55   
   $��1��6   $��1��6   $��2��6-   $��10q�6A   .+�56      &   System.Windows.Controls.DataGrid  -   5          Name$ products��56      
������� J� Opacity$	 0.6Q�6<      
IsReadOnly . 
������ $��5q�6v      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��16(�6�     AzureDataGrid#��[ 6�   	 � ContextMenu	 57      �� 58      .@�59      m� -   5        $��Eliminar��59   #   65   5:      5<      5=      +  %MahApps.Metro.Controls.FlyoutsControl  5>   
   $��2��6"   $��2��62   .@�5?      #  MahApps.Metro.Controls.Flyout  -   5        
  Name$
 fly_add��5?         Position$ Right=�6/   $��Nuevo producto��6@   ���#6d8fc6   IsOpen .  .��5@      (� $��5q�6   .��5A      �� .+�5B      �� $��Nombre de producto��6$   �� 5C      -   5         ��Name$ 
tbx_nombre��5C   /   $��1��6"   6/   �� 5D      $��2��6$   $��Precio��61   �� 5E      -   5        $��
tbx_precio��5E   0   $��3��6"   60   �� 5F       �� Orientation$ 
Horizontal=�6%   $��4��6>   .+�5G      �� -	   5        $ bt_add_cancel��5G   %   
���   �$��25��6O   
�������$	 0.8Q�6x   $��3q�6�   #��[ 6�   $��Cancelar��6�   6�   �� 5H      -
   5        $ 	bt_add_ok��5H   &   
���   �$��Agregar��6L   $��25��6^   $��1��6m   
�������$	 0.8Q�6�   $��3q�6�   #��[ 6�   6�   5I      5J      5K      5L      5M        5N   
   $��2��6#   $��2��63   .@�5O        -   5        $
 fly_edit��5O      $ Right=�60   $��Editar producto��6A   ���#6d8fc6 .  .��5P      (� $��5q�6   .��5Q      �� .+�5R      �� $��Nombre de producto��6$   �� 5S      -   5        $ tbx_edit_nombre��5S   /   $��1��6"   6/   �� 5T      $��2��6$   $��Precio��61   �� 5U      -   5        $��tbx_edit_precio��5U   0   $��3��6"   60   �� 5V      $ 
Horizontal=�6%   $��4��6>   .+�5W      �� -   5        $ bt_edit_cancel��5W   %   
���   �$��25��6P   
�������$	 0.8Q�6y   $��3q�6�   #��[ 6�   $��Cancelar��6�   6�   �� 5X      -   5        $ 
bt_edit_ok��5X   &   
���   �$��Agregar��6M   $��25��6_   $��1��6n   
�������$	 0.8Q�6�   $��3q�6�   #��[ 6�   6�   5Y      5Z      5[      5\      5]        5^   
   $��2��6#   $��2��63   .@�5_        -   5        $
 
fly_delete��5_      $ Right=�62    .  ���#6d8fc6$��Eliminar producto��6g   .��5`      (� $��Stretch=�6   $��5q�68   .��5a      �� .+�5b      �� -   5         ��Name$ tbl_pegunta��5b   $   �� 5c      $ 
Horizontal=�6%   $��25��6>   $��Center=�6N   .+�5d      �� -   5        $ btn_no��5d   &   
���   �$��50��6I   $��Cancelar��6T   $��25��6i   $��1��6x   
�������$	 0.8Q�6�   $��3q�6�   #��[ 6�   6�   �� 5e      -   5        $ btn_yes��5e   %   
���   �$��50��6I   $��25��6T   
�������$	 0.8Q�6|   $��3q�6�   #��[ 6�   $��Eliminar��6�   6�   5f      5g      5h      5i      5j      �� 5k   
   -   5        $ btn_back��5k   !   $��0��6   
������ 
������ .��5l      (� .��5m      �� $��imagenes/undo.png��6   5n      5o      (� 5p   
   $��1��6   .��5q      �� $��	Productos��6   $��2��6)   
������� �� TextAlignment$ Center=�6Q   $��Center=�6h   $��5q�6�   5r      5s      5t      