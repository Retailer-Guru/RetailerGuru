import { Component, Input, OnInit } from '@angular/core';
import { ItemList } from 'src/app/models/item-list-model';
import { Product } from 'src/app/models/product-model';
import { GlobalService } from 'src/clients/global_service';

@Component({
  selector: 'app-productsview',
  templateUrl: './productsview.component.html',
  styleUrls: ['./productsview.component.css']
})
export class ProductsviewComponent implements OnInit {

  constructor(private client : GlobalService) { }

  products : Product[] = [];

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.client.getObject<ItemList<Product>>("/api/v1-spa/Product/GetProdcuts")
      .subscribe(res => {
        this.products = res.items;
      })
  }

}
