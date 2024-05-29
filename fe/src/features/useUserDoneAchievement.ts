import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useUserDoneAchievement = () => {
  return useMutation((data: { id: string; achievement: string }) => {
    return fetchAbstract(
      "UserTypes/" + data.id + "?achievementToComplete=" + data.achievement,
      "PATCH",
    );
  });
};
