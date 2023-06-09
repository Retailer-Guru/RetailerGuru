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
  bild2:string = 'assets/images/lisa.jpg';
  bild3:string = 'assets/images/tobi.jpg';

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    return (token && !this.jwtHelper.isTokenExpired(token));
  }
}

