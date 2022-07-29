import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { NoAuthGuard } from './core/auth/guards/noAuth.guard';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'signed-in-redirect', pathMatch: 'full', redirectTo: 'home' },
  {
    path: '',
    canActivate: [NoAuthGuard],
    canActivateChild: [NoAuthGuard],
    component: LayoutComponent,
    children: [
      {
        path: 'home',
        loadChildren: (): any => import('app/modules/home/home.module').then(m => m.HomeModule),
      },
      {
        path: 'produto',
        loadChildren: (): any => import('app/modules/produto/produto.module').then(m => m.ProdutoModule),
      },
    ],
  },
  // Otherwise redirect to home
  { path: '**', redirectTo: 'sign-in' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules,
      scrollPositionRestoration: 'enabled',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
