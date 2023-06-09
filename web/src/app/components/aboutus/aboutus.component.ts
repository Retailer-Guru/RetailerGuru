import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-aboutus',
  templateUrl: './aboutus.component.html',
  styleUrls: ['./aboutus.component.css']
})
export class AboutusComponent implements OnInit {

  constructor(private jwtHelper : JwtHelperService) { }

  ngOnInit() {
  }

  bild1:string = 'assets/images/1234.png';
  bild2:string = 'assets/images/bild2.png';
  bild3:string = 'assets/images/bild5.jpg';
  bild4:string = 'assets/images/bild6.jpg';
  bild5:string = 'assets/images/bild7.jpg';
  bild6:string = 'assets/images/bild8.jpg';
  bild7:string = 'assets/images/bild9.jpg';
  bild8:string = 'assets/images/bild4.jpg';

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    return (token && !this.jwtHelper.isTokenExpired(token));
  }
}

