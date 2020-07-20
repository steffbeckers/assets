# Assets

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 10.0.3.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

This app generated
`ng new assets`

NgRx
https://ngrx.io/guide/schematics
`npm install @ngrx/schematics @ngrx/store @ngrx/effects @ngrx/entity @ngrx/store-devtools`
`ng generate @ngrx/schematics:store State --root --statePath store --module app.module.ts`
`ng generate @ngrx/schematics:effect store/App --root --module app.module.ts --group`

Auth module and state
`ng generate module auth --route auth --module app.module.ts`
`ng generate feature auth/store/Auth --module auth/auth.module.ts --group`

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
