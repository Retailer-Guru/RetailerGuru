import { Component, OnInit } from '@angular/core';
import { ItemList } from 'src/app/models/item-list-model';
import { GlobalService } from 'src/clients/global_service';
import { Product } from 'src/app/models/product-model'

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchInput : string = "";
  outputlist : Product[] = [];

  constructor(private client : GlobalService) { }

  ngOnInit() {
  }

  search() {
    if(!this.searchInput)
      return;

    this.client.getObject('/api/v1-spa/Search/GetProductSearch' + '/' + this.searchInput)
      .subscribe(res => {
        this.outputlist = (<any>res).result.items;
      });
  }
}
