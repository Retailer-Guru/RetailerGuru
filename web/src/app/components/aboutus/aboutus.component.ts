import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-aboutus',
  templateUrl: './aboutus.component.html',
  styleUrls: ['./aboutus.component.css']
})
export class AboutusComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  bild1:string = 'assets/images/1234.png';
  bild2:string = 'assets/images/lisa.jpg';
  bild3:string = 'assets/images/tobi.jpg'
}

