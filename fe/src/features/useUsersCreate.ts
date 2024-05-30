import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { UserType } from "../types/User";
import {
  MAP_ROLE_REVERSE,
  MAP_SUBSCRIPTION_REVERSE,
} from "./useUserGetAllQuery";
import { INGREDIENTS } from "../utils/ingredients";

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
      ...data,
      id: data.typeId,
      userId: data.id,
      role: MAP_ROLE_REVERSE[data.role as "admin" | "user"],
      subscription:
        MAP_SUBSCRIPTION_REVERSE[data.subscription as "t-1" | "t-2" | "t-3"],
      bannedIngredientIds: data.bannedIngredients
        .map((ingredient) => INGREDIENTS.find((i) => i.name === ingredient)?.id)
        .filter(Boolean),
    });
  });
};
