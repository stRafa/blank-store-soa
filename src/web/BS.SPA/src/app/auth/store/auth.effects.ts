import { ICurrentUser } from './../../shared/types/currentUser.interface';
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { AuthService } from "../services/auth.service";
import { inject } from "@angular/core";
import { authActions } from "./auth.actions";
import { catchError, map, of, switchMap, tap } from "rxjs";
import { HttpErrorResponse } from '@angular/common/http';
import { PersistenceService } from '../../shared/services/persistence.service';
import { Router } from '@angular/router';

// Register Effects

export const registerEffect = createEffect(
  (actions$ = inject(Actions), authService = inject(AuthService), persistanceService = inject(PersistenceService)) => {
  return actions$.pipe(
    ofType(authActions.register),
    switchMap(({request}) => {
      return authService.register(request).pipe(
        map((currentUser: ICurrentUser) => {
          persistanceService.set('accessToken', currentUser.token)
          return authActions.registerSuccess({ currentUser })
        }),
        catchError((errorResponse: HttpErrorResponse) => of(authActions.registerFailure({errors: errorResponse.error.errors})))
      )
    })
  )
}, {functional: true})

export const redirectAfterRegisterEffect = createEffect(
  (actions$ = inject(Actions), router = inject(Router)) => {
    return actions$.pipe(
      ofType(authActions.registerSuccess),
      tap(() => {
        router.navigateByUrl('/')
      })
    )
  }, {functional: true, dispatch: false}
)


// Login Effects

export const loginEffect = createEffect(
  (actions$ = inject(Actions), authService = inject(AuthService), persistanceService = inject(PersistenceService)) => {
  return actions$.pipe(
    ofType(authActions.login),
    switchMap(({request}) => {
      return authService.login(request).pipe(
        map((currentUser: ICurrentUser) => {
          persistanceService.set('accessToken', currentUser.token)
          return authActions.loginSuccess({ currentUser })
        }),
        catchError((errorResponse: HttpErrorResponse) => of(authActions.loginFailure({errors: errorResponse.error.errors})))
      )
    })
  )
}, {functional: true})

export const redirectAfterLoginEffect = createEffect(
  (actions$ = inject(Actions), router = inject(Router)) => {
    return actions$.pipe(
      ofType(authActions.loginSuccess),
      tap(() => {
        router.navigateByUrl('/')
      })
    )
  }, {functional: true, dispatch: false}
)
