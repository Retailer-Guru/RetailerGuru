import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { delay, of } from 'rxjs';
import { Product } from 'src/app/models/product-model';
import { GlobalService } from 'src/clients/global_service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() product : Product = new Product();
  @Input() viewOnly : boolean = false;
  @Input() newProduct : boolean = false;
  @Output() reload = new EventEmitter();

  constructor(private client : GlobalService, private modalService : NgbModal) { }

  ngOnInit() {
  }

  delete(){
    this.client.deleteObject<Product>("api/v1-spa/Product/DeleteProduct/" + this.product.id)
    .subscribe(() => {
      this.reload.emit();
      this.closeModal();
    });
  }

  forceExternalReload(reload : boolean){
    if(!reload)
      return;
    this.closeModal();
    this.reload.emit();
  }

  openModal(content : any){
    this.modalService.open(content)
  }

  closeModal() {
    this.modalService.dismissAll();
  }

}
