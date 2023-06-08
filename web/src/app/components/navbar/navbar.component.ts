import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private jwtHelper : JwtHelperService, private router : Router, private modalService : NgbModal) { }

  closeResult = '';

  ngOnInit() {

  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    return (token && !this.jwtHelper.isTokenExpired(token));
  }

  logout() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("userId");
    localStorage.removeItem("companyId");

    this.router.navigate(["home"])
    window.location.reload();
  }

  openModal(content : any){
    this.modalService.open(content, { size: "xl" })
  }

  closeModal() {
    this.modalService.dismissAll();
  }


}
