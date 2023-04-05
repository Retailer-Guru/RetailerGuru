import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-productsview',
  templateUrl: './productsview.component.html',
  styleUrls: ['./productsview.component.css']
})
export class ProductsviewComponent implements OnInit {

  constructor() { }

  products : any;

  ngOnInit() {
    this.loadData();
  }

  private loadData(){

  }

}
