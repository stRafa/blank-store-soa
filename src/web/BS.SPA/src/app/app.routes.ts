import { Route } from "@angular/router";

export const appRoutes: Route[] = [
  {
    path: 'register',
    loadChildren: () => import('./auth/auth.routes').then(p => p.registerRoutes)
  },
  {
    path: 'login',
    loadChildren: () => import('./auth/auth.routes').then(p => p.loginRoutes)
  },
]
