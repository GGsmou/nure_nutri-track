export interface UserTypeResponse {
  id: string;
  userName: string;
  email: string;
  userType: UserType | null;
  favoriteRecipes: any[];
  shoppingList: any[];
}

export interface WaterNote {
  user: User | null;
  userId: string;
  createdAt: string;
  ml: number;
  id: string;
}

export interface UserType {
  user: User;
  userId: string;
  name: string;
  role: number;
  subscription: number;
  bannedIngredients: any;
  dailyCalories: number;
  weight: number;
  desiredWeight: number;
  hydrated: boolean;
  exercised: boolean;
  ateHealthy: boolean;
  chef: boolean;
  critic: boolean;
  criticTwoPointO: boolean;
  social: boolean;
  id: string;
}

export interface User {
  favoriteRecipes: any[];
  shoppingList: any[];
  hydrations: any;
  waterNotes: any;
  recipeComments: any;
  exercisesNotes: any;
  calorieNotes: any;
  userType: any;
  id: string;
  userName: string;
  normalizedUserName: string;
  email: string;
  normalizedEmail: string;
  emailConfirmed: boolean;
  passwordHash: string;
  securityStamp: string;
  concurrencyStamp: string;
  phoneNumber: any;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd: any;
  lockoutEnabled: boolean;
  accessFailedCount: number;
}
