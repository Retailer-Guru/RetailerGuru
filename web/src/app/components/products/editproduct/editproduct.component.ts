import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/models/product-model';
import { GlobalService } from 'src/clients/global_service';

@Component({
  selector: 'app-editproduct',
  templateUrl: './editproduct.component.html',
  styleUrls: ['./editproduct.component.css']
})
export class EditproductComponent implements OnInit {

  @Input() modelId : number = 0;
  @Output() reload = new EventEmitter<boolean>();

  editproduct : Product = new Product();
  companyId : string = "";

  constructor(private client : GlobalService) {  }

  ngOnInit() {
    if(!this.modelId || this.modelId === 0)
      return;

    this.client.getObject<Product>("/api/v1-spa/Product/GetProduct/" + this.modelId?.toString())
      .subscribe(res => {
        this.editproduct = res;
      });
  }

  submit(cancel : boolean){
    if(cancel){
      this.reload.emit(false);
    }

    this.editproduct.companyId = localStorage.getItem("companyId") ?? "";

    if(this.modelId == 0){
      this.client.postObject<Product>("/api/v1-spa/Product/AddProduct", this.editproduct)
        .subscribe(() => {
          this.reload.emit(true);
        });
    }
    else{
      this.client.postObject<Product>("/api/v1-spa/Product/UpdateProduct", this.editproduct)
        .subscribe(() => {
          this.reload.emit(true);
        });
    }

    this.reload.emit(false);
  }

}
