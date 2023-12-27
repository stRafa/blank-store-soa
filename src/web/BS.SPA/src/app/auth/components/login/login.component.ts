import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { selectIsSubmitting, selectValidationErrors } from '../../store/auth.reducer';
import { combineLatest } from 'rxjs';
import { Store } from '@ngrx/store';
import { BackendErrorMessagesComponent } from "../../../shared/components/backendErrorMessages/backendErrorMessages.component";
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { authActions } from '../../store/auth.actions';
import { ILoginRequest } from '../../types/loginRequest.interface';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    standalone: true,
    imports: [ReactiveFormsModule, RouterLink, CommonModule, BackendErrorMessagesComponent]
})
export class LoginComponent {
  form = this.fb.nonNullable.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  })
  validationErrors$ = this.store.select(selectValidationErrors);

  isSubmitting$ = this.store.select(selectIsSubmitting)

  data$ = combineLatest({
    isSubmitting: this.store.select(selectValidationErrors),
    backendErrors: this.store.select(selectValidationErrors)
  })

  constructor(
    private fb: FormBuilder,
    private store: Store
  ) {}

  onSubmit(){
    console.log('form', this.form.getRawValue())
    const request: ILoginRequest = {
      user: this.form.getRawValue()
    }
    this.store.dispatch(authActions.login({ request }))
  }
}
