import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { LoginModel } from 'src/app/models/login-model';
import { GlobalService } from 'src/clients/global_service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Output() buttonPressed = new EventEmitter();

  loginModel : LoginModel = new LoginModel();

  constructor(private client : GlobalService) { }

  ngOnInit() {
  }

  login()
  {
    if(this.loginModel.username === "")
      return;

    if(this.loginModel.password === "")
      return;

    this.buttonPressed.emit();

    this.client.postObject("api/v1-spa/Auth/Login", this.loginModel)
      .subscribe(res => {
        localStorage.setItem("jwt", (<any>res).token);
        localStorage.setItem("userId", (<any>res).userId);
        localStorage.setItem("companyId", (<any>res).companyId);
      });
  }

}
