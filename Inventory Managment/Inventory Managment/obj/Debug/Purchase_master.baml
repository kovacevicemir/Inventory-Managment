   M S B A M L   `   `   `  ����N  JInventory Managment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Inventory_ManagmentInventory_Managment  5   	   )    #Inventory_Managment.Purchase_master   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Inventory_Managment     5   	     � Title$  Purchase Master��5   	   $	��800��5	   	   $
��1024��5
   	   $��13(�6   .��5      � ��5   
   �� 5       �� Color# � ��6   .+�5   
   �� -   5         ��Name$ label��5      $��Product Name��6   $
��Left=�66   $��140,108,0,0q�6Q   $	��Top=�6f   $
��Bold"�6~   �� 5   
   -   5        $ 
label_Copy��5      $��Product Quantity��6$   $
��Left=�6?   $��140,161,0,0q�6Z   $	��Top=�6o   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy2��5      $��Product Price��6%   $
��Left=�6=   $��140,213,0,0q�6X   $	��Top=�6m   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy3��5      $��Product Total��6%   $
��Left=�6=   $��140,271,0,0q�6X   $	��Top=�6m    J� RenderTransformOrigin$ 0.718,6.574&�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy4��5      $��Purchase Date��6%   $
��Left=�6=   $��140,332,0,0q�6X   $	��Top=�6m   $ 0.958,2.206&�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy5��5      $��Dealer Name��6%   $
��Left=�6;   $��140,392,0,0q�6V   $	��Top=�6k   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy6��5      $��Purchase Type��6%   $
��Left=�6=   $��140,447,0,0q�6X   $	��Top=�6m   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy7��5      $��Expiry Date��6%   $
��Left=�6;   $��140,502,0,0q�6V   $	��Top=�6k   $
��Bold"�6�   �� 5   
   -	   5        $ label_Copy8��5      $��Profit %��6%   $
��Left=�68   $��140,556,0,0q�6S   $	��Top=�6h   $
��Bold"�6�   �� 5   
   -
   5         ��Name$ comboBox_product_name��5      $
��Left=�62   $��316,108,0,0q�6M   $	��Top=�6b   $	��120��6z   6�   �� 5   
   -   5         ��Name$ input_product_quantity��5      $
��Left=�62   $��23��6M   $��316,161,0,0q�6Y    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ input_product_price��5      $
��Left=�6/   $��23��6J   $��316,213,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��120��6�   6�   �� 5   
   -   5        $ input_total��5      $
��Left=�6'   $��23��6B   $��316,271,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ input_purchase_date��5      $
��Left=�62   $��316,332,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ comboBox_dealer_name��5      $
��Left=�61   $��316,392,0,0q�6L   $	��Top=�6a   $	��120��6y   �� 5   
   -   5        $ comboBox_purchase_type��5      $
��Left=�63   $��316,447,0,0q�6N   $	��Top=�6c   $	��120��6{     5    
   -   5        $ input_expiry_date��5       $
��Left=�60   $��316,502,0,0q�6K   $	��Top=�6`   �� 5!   
   -   5        $ input_profit��5!      $
��Left=�6(   $��23��6C   $��316,556,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5"   
   -   5         ��Name$ btn_purchase_item��5"      $��Purchase Item��6,   $
��Left=�6D   $��316,624,0,0q�6_   $	��Top=�6t   $	��120��6�   $��29��6�   6�   �� 5#   
   -   5        $ Unit_display��5#      	 �� 
IsReadOnly	 . $
��Left=�6:   $��23��6U   $��441,161,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $��75��6�   $ 0.055,0.639&�6�   5$      5%      