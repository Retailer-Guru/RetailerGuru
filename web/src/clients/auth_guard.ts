import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";

export const AuthGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const token = localStorage.getItem("jwt");
  const jwtHelper = inject(JwtHelperService);
  const router = inject(Router);

  if(token && !jwtHelper.isTokenExpired(token))
    return true;

  router.navigate(["login"]);
  return false;
}
