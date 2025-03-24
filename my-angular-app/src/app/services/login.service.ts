import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface APIResponseModel {  // Ensure it's exported if used in multiple files
  isSuccess: boolean;
  message: string;
  data: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private baseUrl = 'https://localhost:7000/api/User/ValidateCredential'; // Update with actual API URL

  constructor(private http: HttpClient) {}

  validateCredential(number: number, OTP: number): Observable<APIResponseModel> {
    const url = `${this.baseUrl}/ValidateCredential?number=${number}&OTP=${OTP}`;
    return this.http.get<APIResponseModel>(url);
  }
}
