import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { APIResponseModel, LoginService } from '../services/login.service';  // ✅ Import LoginService


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterModule,FormsModule],
  providers: [LoginService],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  number: number = 0;
  OTP: number = 0;
  loginMessage: string = '';

  constructor(private loginService: LoginService) {}

  onLogin(event: Event) {
    event.preventDefault();

    this.loginService.validateCredential(this.number, this.OTP).subscribe(
      (response:APIResponseModel ) => {
        this.loginMessage = response.isSuccess ? "✅ " + response.message : "❌ " + response.message;
      },
      (error: any) => {
        this.loginMessage = "⚠️ Something went wrong!";
      }
    );
  }
}
