import { bootstrapApplication } from "@angular/platform-browser";
import { AppComponent } from "./app/app.component";
import { provideRouter } from "@angular/router";
import { appRoutes } from "./app/app.routes";
import { provideState, provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { isDevMode } from '@angular/core';
import { authFeatureKey, authReducer } from "./app/auth/store/auth.reducer";
import { provideHttpClient } from "@angular/common/http";
import { provideEffects } from '@ngrx/effects';
import * as authEffects from './app/auth/store/auth.effects'

bootstrapApplication(
  AppComponent,
  {
    providers: [
    provideHttpClient(),
    provideRouter(appRoutes),
    provideStore(),
    provideState(authFeatureKey, authReducer),
    provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode(), autoPause: true, trace: false, traceLimit: 75 }),
    provideEffects(authEffects)
]
  }
)
