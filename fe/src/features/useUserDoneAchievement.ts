import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { urlBuilder } from "../utils/urlBuilder";
import {
  MAP_ROLE,
  MAP_ROLE_REVERSE,
  MAP_SUBSCRIPTION,
  MAP_SUBSCRIPTION_REVERSE,
} from "./useUserGetAllQuery";

export const useUserDoneAchievement = () => {
  return useMutation(async (data: { id: string; achievement: string }) => {
    let us = await fetchAbstract(
      urlBuilder(
        "UserTypes",
        {
          id: data.id,
        },
        true,
      ),
      "GET",
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
    );
    us = Array.isArray(us) ? us : [us];
    us = us[0] as unknown as Record<string, unknown>;
    const uss = {
      ...us,
      id: us.userId,
      role: MAP_ROLE[us.role as 0 | 1],
      subscription: MAP_SUBSCRIPTION[us.subscription as 0 | 1 | 2],
      typeId: us.id,
      bannedIngredients: us.bannedIngredients || [],
      bannedIngredientIds: us.BannedIngredientIds || [],
    };

    return fetchAbstract("UserTypes/", "PUT", {
      ...uss,
      id: uss.typeId,
      userId: uss.id,
      role: MAP_ROLE_REVERSE[uss.role as "admin" | "user"],
      subscription:
        MAP_SUBSCRIPTION_REVERSE[uss.subscription as "t-1" | "t-2" | "t-3"],
      [data.achievement]: true,
    });
  });
};
