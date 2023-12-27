import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegisterRequest } from '../types/registerRequest.interface';
import { ICurrentUser } from '../../shared/types/currentUser.interface';
import { Observable, map } from 'rxjs';
import { IAuthResponse } from '../types/authResponse.interface';
import { environment } from '../../../environments/environment.development';
import { ILoginRequest } from '../types/loginRequest.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  register(data: IRegisterRequest): Observable<ICurrentUser> {
    const url = environment.apiUrl + '/users';

    return this.http.post<IAuthResponse>(url, data).pipe(map(this.getUser));
  }

  login(data: ILoginRequest): Observable<ICurrentUser> {
    const url = environment.apiUrl + '/users/login';

    return this.http.post<IAuthResponse>(url, data).pipe(map(this.getUser));
  }

  private getUser = (response: IAuthResponse): ICurrentUser => response.user;
}
