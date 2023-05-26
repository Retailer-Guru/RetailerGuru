import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GlobalService } from 'src/clients/global_service';

@Component({
  selector: 'app-statistikview',
  templateUrl: './statistikview.component.html',
  styleUrls: ['./statistikview.component.css']
})
export class StatistikviewComponent implements OnInit {

  productId : number = 0;

  constructor(private route : ActivatedRoute) {
    let routeParams = this.route.snapshot.paramMap;
    this.productId = +(routeParams.get('productId') ?? "0");
  }

  ngOnInit() {
  }

}
