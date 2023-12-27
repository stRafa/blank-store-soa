import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { authActions } from '../../store/auth.actions';
import { IRegisterRequest } from '../../types/registerRequest.interface';
import { selectIsSubmitting, selectValidationErrors } from '../../store/auth.reducer';
import { IAuthState } from '../../types/authState.interface';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { combineLatest } from 'rxjs';
import { BackendErrorMessagesComponent } from '../../../shared/components/backendErrorMessages/backendErrorMessages.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, CommonModule, BackendErrorMessagesComponent]
})
export class RegisterComponent {
  form = this.fb.nonNullable.group({
    username: ['', Validators.required],
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
    const request: IRegisterRequest = {
      user: this.form.getRawValue()
    }
    this.store.dispatch(authActions.register({ request }))
  }
}
