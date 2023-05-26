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

  product : Product = new Product();
  companyId : string = "";

  constructor(private client : GlobalService) {  }

  ngOnInit() {
    if(!this.modelId)
      return;

    if(this.modelId != 0){
      this.client.getObject<Product>("/api/v1-spa/Product/GetProduct/" + this.modelId?.toString())
        .subscribe(res => {
          this.product = res;
        });
    }
  }

  submit(cancel : boolean){
    if(cancel){
      this.reload.emit(false);
    }

    this.product.companyId = localStorage.getItem("companyId") ?? "";

    if(this.modelId == 0){
      this.client.postObject<Product>("/api/v1-spa/Product/AddProduct", this.product)
        .subscribe(() => {
          this.reload.emit(true);
        });
    }
    else{
      this.client.postObject<Product>("/api/v1-spa/Product/UpdateProduct", this.product)
        .subscribe(() => {
          this.reload.emit(true);
        });
    }
-
    this.reload.emit(false);
  }

}
