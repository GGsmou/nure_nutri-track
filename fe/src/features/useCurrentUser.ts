import { useQuery } from "react-query";
import { User, UserType } from "../types/User";
import { fetchAbstract } from "../utils/fetchAbstract";
import { MAP_ROLE, MAP_SUBSCRIPTION } from "./useUserGetAllQuery";
import { urlBuilder } from "../utils/urlBuilder";
import { authService } from "../utils/authService";

export const useCurrentUser = () => {
  return useQuery("user", async () => {
    const id = authService.getAuthInfo().userId;
    if (!id) {
      return;
    }
    const user = (await fetchAbstract(
      urlBuilder("users", { id }, true),
      "GET",
    )) as User;
    return {
      ateHealthy: user.userType.ateHealthy,
      exercised: user.userType.exercised,
      hydrated: user.userType.hydrated,
      chef: user.userType.chef,
      critic: user.userType.critic,
      criticTwoPointO: user.userType.criticTwoPointO,
      social: user.userType.social,
      email: user.email,
      dailyCalories: user.userType.dailyCalories,
      weight: user.userType.weight,
      desiredWeight: user.userType.desiredWeight,
      name: user.userType.name,
      id: user.id,
      role: MAP_ROLE[user.userType.role as unknown as 0 | 1],
      subscription:
        MAP_SUBSCRIPTION[user.userType.subscription as unknown as 0 | 1 | 2],
      bannedIngredients: user.userType.bannedIngredients || [],
    } as UserType;
  });
};
