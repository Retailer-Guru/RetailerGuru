import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { GlobalService } from 'src/app/services/global.service';

@Component({
  selector: 'app-productsview',
  templateUrl: './productsview.component.html',
  styleUrls: ['./productsview.component.css']
})
export class ProductsviewComponent implements OnInit {

  constructor(private globalService : GlobalService) { }

  products : Product[] = [];

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.globalService.getObject<Product[]>('Product/GetProdcuts')
      .subscribe(res => {
        this.products = res;
        console.log(res);

        console.log(this.products);


      })
  }

}
