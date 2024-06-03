import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { UserType } from "../types/User";
import {
  MAP_ROLE_REVERSE,
  MAP_SUBSCRIPTION_REVERSE,
} from "./useUserGetAllQuery";

export const useUsersCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: UserType) => {
    const type = filter.type === "edit" ? "PUT" : "POST";

    return fetchAbstract("UserTypes/", type, {
      id: data.typeId,
      userId: data.id,
      name: data.name,
      role: MAP_ROLE_REVERSE[data.role as "admin" | "user"],
      subscription:
        MAP_SUBSCRIPTION_REVERSE[data.subscription as "t-1" | "t-2" | "t-3"],
      bannedIngredientIds: [],
      // data.bannedIngredients
      //   .map((ingredient) => INGREDIENTS.find((i) => i.name === ingredient)?.id)
      //   .filter(Boolean),
      dailyCalories: data.dailyCalories,
      weight: data.weight,
      desiredWeight: data.desiredWeight,
      hydrated: data.hydrated,
      exercised: data.exercised,
      ateHealthy: data.ateHealthy,
      chef: data.chef,
      critic: data.critic,
      criticTwoPointO: data.criticTwoPointO,
      social: data.social,
    });
  });
};
