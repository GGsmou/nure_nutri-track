import { useQuery } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { UserType } from "../types/User";
import { urlBuilder } from "../utils/urlBuilder";
import { INGREDIENTS } from "../utils/ingredients";

export const MAP_ROLE = {
  0: "admin",
  1: "user",
};

export const MAP_ROLE_REVERSE = {
  admin: 0,
  user: 1,
};

export const MAP_SUBSCRIPTION = {
  0: "t-1",
  1: "t-2",
  2: "t-3",
};

export const MAP_SUBSCRIPTION_REVERSE = {
  "t-1": 0,
  "t-2": 1,
  "t-3": 2,
};

export const useUserGetAllQuery = (filter: { id?: string }) => {
  return useQuery({
    queryKey: ["users", filter],
    queryFn: async () => {
      const us = await fetchAbstract(
        urlBuilder("UserTypes", filter, true),
        "GET",
      );
      const uss = Array.isArray(us) ? us : [us];

      return uss.map((obj: Record<string, unknown>) => ({
        ...obj,
        id: obj.userId,
        role: MAP_ROLE[obj.role as 0 | 1],
        subscription: MAP_SUBSCRIPTION[obj.subscription as 0 | 1 | 2],
        typeId: obj.id,
        bannedIngredients:
          (
            obj.bannedIngredients as unknown as
              | Record<string, unknown>[]
              | undefined
          )
            ?.map((x) => {
              x.ingredientId;
              INGREDIENTS.find((i) => i.id === x.ingredientId)?.name || "";
            })
            .filter(Boolean) || [],
      })) as unknown as UserType[];
    },
  });
};
