import { createActionGroup, props } from "@ngrx/store";
import { IRegisterRequest } from "../types/registerRequest.interface";
import { ICurrentUser } from "../../shared/types/currentUser.interface";
import { IBackendErrors } from "../../shared/types/backendErrors.interface";
import { ILoginRequest } from "../types/loginRequest.interface";

export const authActions = createActionGroup({
  source: 'Auth',
  events: {
    Register: props<{request: IRegisterRequest}>(),
    'Register Success': props<{currentUser: ICurrentUser}>(),
    'Register Failure': props<{errors: IBackendErrors}>(),

    Login: props<{request: ILoginRequest}>(),
    'Login Success': props<{currentUser: ICurrentUser}>(),
    'Login Failure': props<{errors: IBackendErrors}>()
  }
})



// export const register = createAction(
//   '[Auth] Register',
//   props<{request: IRegisterRequest}>()
// )
