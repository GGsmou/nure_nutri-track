import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { RecepieComment } from "../types/RecepieComment";
import { urlBuilder } from "../utils/urlBuilder";

export const useRecepieCommentCreate = () => {
  return useMutation(async (data: RecepieComment) => {
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
    us = us[0];

    return fetchAbstract("RecipeComment/", "POST", {
      userId: us.userId,
      recipeId: data.recepieId,
      comment: data.comment,
    });
  });
};
